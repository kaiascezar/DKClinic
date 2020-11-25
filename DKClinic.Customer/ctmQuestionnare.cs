using DKClinic.Data;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DKClinic.Customer
{
    public partial class ctmQuestionnare : BaseUC
    {
        public ctmQuestionnare()
        {
            InitializeComponent();
            Title = "문진표";
        }

        public ctmQuestionnare(int departmentId) : this()
        {
            //MultipleChoice question = new MultipleChoice();
            //question.CreateChoiceSingle(6, "1번,2번,3번,4번,5번,6번");
            //q.AddQuestionControl(question);

            //MultipleChoice question2 = new MultipleChoice();
            //question2.CreateChoiceMultiple(6, "1번,2번,3번,4번,5번,6번");
            //q.AddQuestionControl(question2);

            //ShortAnswer question3 = new ShortAnswer();
            //question3.CreateAnswer();
            //q.AddQuestionControl(question3);

            // 1-주관식, 2-객관식, 3-객관식다중선택
            using (var context = DKClinicEntities.Create())
            {
                //int questionCount = context.Departments.Where(x => x.DepartmentID == departmentId);
                //questionList = context.Questions.Where(x => x.DepartmentID == departmentId && x.Index <= questionCount);
                
                foreach(var question in questionList)
                {
                    if(question.Type == 1)
                    {
                        ShortAnswer q = new ShortAnswer();
                        q.CreateAnswer();
                        AddQuestionControl(q);
                    }
                    else if(question.Type == 2)
                    { 
                    }
                    else
                    {
                    }
                }
            }
        }

        public List<Question> questionList { get; set; }
        public List<BaseQuestion> questionUcList { get; set; }

        private int _questionCount = 0;

        // DB연결하면 여기서 문제를 불러오도록 세팅한다
        public void AddQuestionControl(BaseQuestion question)
        {
            _questionCount++;

            question.Dock = DockStyle.Bottom;
            pnlBoard.Controls.Add(question);
            questionUcList.Add(question);
        }
    }
}
