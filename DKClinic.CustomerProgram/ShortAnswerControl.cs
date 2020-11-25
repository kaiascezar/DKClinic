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

        public void CreateAnswer(string question)
        {
            lblQuestion.Text = question;

            RichTextBox txb = new RichTextBox();
            txb.Location = new Point(5, 5);
            txb.Size = new Size(600, 60);
            txb.Font = new Font("Gulim", 14F);
            pnlAnswer.Controls.Add(txb);
        }
    }
}
