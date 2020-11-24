using DKClinic.Data;
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

        private int _questionCount = 0;

        // DB연결하면 여기서 문제를 불러오도록 세팅한다
        public void AddQuestionControl(BaseQuestion question)
        {
            _questionCount++;

            question.Dock = DockStyle.Bottom;
            pnlBoard.Controls.Add(question);
        }
    }
}
