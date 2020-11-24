using DKClinic.Data;

namespace DKClinic.Customer
{
    public partial class BaseQuestion : BaseUC
    {
        public BaseQuestion()
        {
            InitializeComponent();

            lblQuestion.Text = "문제다아ㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏ" +
                "ㅏㅏㅏㅏㅏㅏㅏㅏㅏㅏㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹ" +
                "ㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹㄹ";
        }

        public string Answer { get; set; }
    }
}
