using DKClinic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DKClinic.CustomerProgram
{
    public partial class CustomerQuestionnareControl : BaseUC
    {
        public List<BaseQuestionControl> QuestionControls { get; set; } = new List<BaseQuestionControl>();
        public List<Response> Responses { get; set; } = new List<Response>();
        private int _questionCount;

        public CustomerQuestionnareControl()
        {
            InitializeComponent();
            Title = "문진표";
            _questionCount = 0;
        }

        public CustomerQuestionnareControl(int departmentId) : this()
        {
            _questionCount = Dao.Department.GetQuestionCount(departmentId);
            
            CreateQuestionControlList(departmentId);

            CreateConfirmButton();
        }

        // 패널 안에 입력완료 버튼을 만들어준다
        private void CreateConfirmButton()
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Bottom
            };
            pnlBoard.Controls.Add(panel);

            Button button = new Button
            {
                Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129))),
                Location = new System.Drawing.Point(700, 0),
                Size = new System.Drawing.Size(200, 80),
                TabIndex = 3,
                Text = "입력완료"
            };
            button.Click += new EventHandler(btnConfirm_Click);
            panel.Controls.Add(button);
        }

        // 입력완료 버튼 클릭시 답안 입력을 검사하고 이벤트를 발동한다
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 만일 값이 다 입력되지 않았다면 되돌린다
            for(int i = 0; i < QuestionControls.Count; i++)
            {
                string answer = QuestionControls[i].CheckAnswer();

                if (answer == null)
                {
                    MessageBox.Show("답안을 전부 입력해 주세요", "확인");
                    return;
                }

                // 값을 responses에 저장한다
                Responses[i].Answer = answer;
            }

            MessageBox.Show("작성이 완료되었습니다.", "확인");
            // 이벤트를 발생시켜서 response를 보낸다
            OnQuestionnareConfirm(Responses);
        }

        // 문제 컨트롤 리스트를 생성한다
        public void CreateQuestionControlList(int departmentId)
        {
            List<Question> questionList = Dao.Question.GetByDepartmentID(departmentId);

            // 불러온 문제 중에서 버전이 제일 높은 문제를 UC로 출력
            // 1-주관식, 2-객관식, 3-객관식다중선택
            for (int i = 0; i < _questionCount; i++)
            {
                Question question = CheckVersion(questionList, i+1);

                CreateQuestionControl(question, i+1);
            }
        }

        // 해당 문제 데이터를 이용해 문제 컨트롤을 생성한다
        public void CreateQuestionControl(Question question, int number)
        {
            BaseQuestionControl baseQuestion;

            if (question.Type == 1)
            {
                baseQuestion = new ShortAnswerControl(number);
                ((ShortAnswerControl)baseQuestion).CreateAnswer(question.Item);
            }
            else if (question.Type == 2)
            {
                baseQuestion = new MultipleChoiceControl(number);
                ((MultipleChoiceControl)baseQuestion).
                    CreateChoiceSingle(question.Item, (int)question.ChoiceCount, question.Choices);
            }
            else
            {
                baseQuestion = new MultipleChoiceControl(number);
                ((MultipleChoiceControl)baseQuestion).
                    CreateChoiceMultiple(question.Item, (int)question.ChoiceCount, question.Choices);
            }
            AddQuestionControl(baseQuestion);
            Responses.Add(new Response() { QuestionID = question.QuestionID });
        }

        // 해당 번호의 문제들만 뽑아, version이 제일 높은 문제를 뽑는다
        public Question CheckVersion(List<Question> questionList, int index)
        {
            List<Question> list = questionList.FindAll(x => x.Index == index);
            return list.OrderByDescending(x => x.Version).ToList()[0];
        }
        
        // 생성한 문제 컨트롤을 패널에 넣어준다
        public void AddQuestionControl(BaseQuestionControl question)
        {
            question.Dock = DockStyle.Bottom;
            pnlBoard.Controls.Add(question);
            QuestionControls.Add(question);
        }

        // 작성 완료 버튼 이벤트
        #region QuestionnareConfirm event things for C# 3.0
        public event EventHandler<QuestionnareConfirmEventArgs> QuestionnareConfirm;

        protected virtual void OnQuestionnareConfirm(QuestionnareConfirmEventArgs e)
        {
            if (QuestionnareConfirm != null)
                QuestionnareConfirm(this, e);
        }

        private QuestionnareConfirmEventArgs OnQuestionnareConfirm(List<Response> responses)
        {
            QuestionnareConfirmEventArgs args = new QuestionnareConfirmEventArgs(responses);
            OnQuestionnareConfirm(args);

            return args;
        }

        private QuestionnareConfirmEventArgs OnQuestionnareConfirmForOut()
        {
            QuestionnareConfirmEventArgs args = new QuestionnareConfirmEventArgs();
            OnQuestionnareConfirm(args);

            return args;
        }

        public class QuestionnareConfirmEventArgs : EventArgs
        {
            public List<Response> Responses { get; set; }

            public QuestionnareConfirmEventArgs()
            {
            }

            public QuestionnareConfirmEventArgs(List<Response> responses)
            {
                Responses = responses;
            }
        }
        #endregion
    }
}
