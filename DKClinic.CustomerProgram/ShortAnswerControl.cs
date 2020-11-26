using System.Drawing;
using System.Windows.Forms;

namespace DKClinic.CustomerProgram
{
    public partial class ShortAnswerControl : BaseQuestionControl
    {
        public ShortAnswerControl()
        {
            InitializeComponent();
        }

        public ShortAnswerControl(int number) : this()
        {
            lblQuestion.Text = number.ToString() + ". ";
        }

        public void CreateAnswer(string question)
        {
            lblQuestion.Text = lblQuestion.Text + question;

            RichTextBox txb = new RichTextBox();
            txb.Location = new Point(5, 5);
            txb.Size = new Size(600, 60);
            txb.Font = new Font("Gulim", 14F);
            txb.TabStop = false;
            pnlAnswer.Controls.Add(txb);
        }

        public override string CheckAnswer()
        {
            RichTextBox txb = pnlAnswer.Controls[0] as RichTextBox;
            if (txb.Text == "") return null;
            return txb.Text;
        }
    }
}
