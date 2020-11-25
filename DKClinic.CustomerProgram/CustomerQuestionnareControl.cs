using DKClinic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DKClinic.CustomerProgram
{
    public partial class CustomerQuestionnareControl : BaseUC
    {
        public List<BaseQuestionControl> QuestionControls { get; set; }
        public List<Response> Responses { get; set; }
        private int _questionCount = 0;

        public CustomerQuestionnareControl()
        {
            InitializeComponent();
            Title = "문진표";
        }

        public CustomerQuestionnareControl(int departmentId) : this()
        {
            _questionCount = Dao.Department.GetQuestionCount(departmentId);
            
            CreateQuestionControlList(departmentId);
        }

        private void CreateQuestionControlList(int departmentId)
        {
            List<Question> questionList = Dao.Question.GetQuestions(departmentId);

            // 불러온 문제 중에서 버전이 제일 높은 문제를 UC로 출력
            // 1-주관식, 2-객관식, 3-객관식다중선택
            for (int i = 0; i < _questionCount; i++)
            {
                Question question = CheckVersion(questionList, i);

                CreateQuestionControl(question);
            }
        }

        // 해당 문제 데이터를 이용해 UC를 생성한다
        private void CreateQuestionControl(Question question)
        {
            BaseQuestionControl baseQuestion;

            if (question.Type == 1)
            {
                baseQuestion = new ShortAnswerControl();
                ((ShortAnswerControl)baseQuestion).CreateAnswer();
            }
            else if (question.Type == 2)
            {
                baseQuestion = new MultipleChoiceControl();
                ((MultipleChoiceControl)baseQuestion).
                    CreateChoiceSingle((int)question.ChoiceCount, question.Choices);
            }
            else
            {
                baseQuestion = new MultipleChoiceControl();
                ((MultipleChoiceControl)baseQuestion).
                    CreateChoiceMultiple((int)question.ChoiceCount, question.Choices);
            }
            AddQuestionControl(baseQuestion);
            Responses.Add(new Response() { QuestionID = question.QuestionID });
        }

        // 해당 번호의 문제들만 뽑아, version이 제일 높은 문제를 뽑는다
        private Question CheckVersion(List<Question> questionList, int index)
        {
            List<Question> list = questionList.FindAll(x => x.Index == index);
            return list.OrderByDescending(x => x.Version).ToList()[0];
        }

        public void AddQuestionControl(BaseQuestionControl question)
        {
            _questionCount++;

            question.Dock = DockStyle.Bottom;
            pnlBoard.Controls.Add(question);
            QuestionControls.Add(question);
        }
    }
}
