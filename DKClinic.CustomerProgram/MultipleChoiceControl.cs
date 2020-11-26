using System.Drawing;
using System.Windows.Forms;

namespace DKClinic.CustomerProgram
{
    public partial class MultipleChoiceControl : BaseQuestionControl
    {
        private int _choiceType = 0;

        public MultipleChoiceControl()
        {
            InitializeComponent();
        }

        public void CreateChoiceSingle(string question, int count, string choices)
        {
            lblQuestion.Text = question;

            string[] texts = choices.Split(',');
            for(int i = 0; i < count; i++)
            {
                RadioButton rb = new RadioButton();
                rb.Location = new Point(i * 120 + 30, 10);
                rb.AutoSize = false;
                rb.Size = new Size(80, 30);
                rb.Font = new Font("Gulim", 14F);
                rb.Text = texts[i];
                rb.Tag = i + 1;
                pnlAnswer.Controls.Add(rb);
            }

            _choiceType = 1;
        }

        public void CreateChoiceMultiple(string question, int count, string chioces)
        {
            lblQuestion.Text = question;

            string[] texts = chioces.Split(',');
            for (int i = 0; i < count; i++)
            {
                CheckBox cb = new CheckBox();
                cb.Location = new Point(i * 120 + 30, 10);
                cb.AutoSize = false;
                cb.Size = new Size(80, 30);
                cb.Font = new Font("Gulim", 14F);
                cb.Text = texts[i];
                cb.Tag = i + 1;
                pnlAnswer.Controls.Add(cb);
            }

            _choiceType = 2;
        }

        public override string CheckAnswer()
        {
            if(_choiceType == 1)
            {
                foreach (RadioButton item in pnlAnswer.Controls)
                {
                    if (item.Checked)
                        return item.Tag.ToString();
                }

                return null;
            }
            else
            {
                //체크버튼
                string result = null;

                foreach (CheckBox item in pnlAnswer.Controls)
                {
                    if (item.Checked)
                    {
                        if (result == null)
                            result = item.Tag.ToString();
                        else
                            result = result + "," + item.Tag.ToString();

                    }
                }
                return result;
            }
        }
    }
}
