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
        }

        // 테스트용
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode)
                return;

            _questionCount = Dao.Department.GetQuestionCount(1);

            CreateQuestionControlList(1);

            CreateConfirmButton();
        }

        private void CreateConfirmButton()
        {
            Panel panel = new Panel();
            panel.Dock = DockStyle.Bottom;
            pnlBoard.Controls.Add(panel);

            Button button = new Button();
            button.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            button.Location = new System.Drawing.Point(700, 0);
            button.Size = new System.Drawing.Size(200, 80);
            button.TabIndex = 3;
            button.Text = "입력완료";
            button.Click += new EventHandler(btnConfirm_Click);
            
            panel.Controls.Add(button);
        }

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

            // 이벤트를 발생시켜서 response를 보낸다
            OnQuestionnareConfirm(Responses);
        }

        public void CreateQuestionControlList(int departmentId)
        {
            List<Question> questionList = Dao.Question.GetQuestions(departmentId);

            // 불러온 문제 중에서 버전이 제일 높은 문제를 UC로 출력
            // 1-주관식, 2-객관식, 3-객관식다중선택
            for (int i = 0; i < _questionCount; i++)
            {
                Question question = CheckVersion(questionList, i+1);

                CreateQuestionControl(question);
            }
        }

        // 해당 문제 데이터를 이용해 UC를 생성한다
        public void CreateQuestionControl(Question question)
        {
            BaseQuestionControl baseQuestion;

            if (question.Type == 1)
            {
                baseQuestion = new ShortAnswerControl();
                ((ShortAnswerControl)baseQuestion).CreateAnswer(question.Item);
            }
            else if (question.Type == 2)
            {
                baseQuestion = new MultipleChoiceControl();
                ((MultipleChoiceControl)baseQuestion).
                    CreateChoiceSingle(question.Item, (int)question.ChoiceCount, question.Choices);
            }
            else
            {
                baseQuestion = new MultipleChoiceControl();
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

        public void AddQuestionControl(BaseQuestionControl question)
        {
            question.Dock = DockStyle.Bottom;
            pnlBoard.Controls.Add(question);
            QuestionControls.Add(question);
        }

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

        private void pnlBoard_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show(pnlBoard.Focused.ToString());
        }

        private void pnlBoard_Click(object sender, EventArgs e)
        {
            MessageBox.Show(pnlBoard.Focused.ToString());
        }

        private void pnlBoard_Scroll(object sender, ScrollEventArgs e)
        {
            MessageBox.Show(pnlBoard.Focused.ToString());
        }

        private void pnlBoard_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(pnlBoard.Focused.ToString());
        }
    }
}
