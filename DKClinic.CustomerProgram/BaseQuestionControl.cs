using DKClinic.Data;

namespace DKClinic.CustomerProgram
{
    public abstract partial class BaseQuestionControl : BaseUC
    {
        public BaseQuestionControl()
        {
            InitializeComponent();

            lblQuestion.Text = string.Empty;
        }

        public string Answer { get; set; }

        public abstract string CheckAnswer();
    }
}
