using DKClinic.Data;

namespace DKClinic.CustomerProgram
{
    public partial class BaseQuestionControl : BaseUC
    {
        public BaseQuestionControl()
        {
            InitializeComponent();

            lblQuestion.Text = "문제다아ㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏ" +
                "ㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹ" +
                "ㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹ";
        }

        public string Answer { get; set; }
    }
}
