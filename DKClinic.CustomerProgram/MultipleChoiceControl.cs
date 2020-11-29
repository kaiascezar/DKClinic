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

        public MultipleChoiceControl(int number) : this()
        {
            lblQuestion.Text = number.ToString() + ". ";
        }

        public void CreateChoiceSingle(string question, int count, string choices)
        {
            lblQuestion.Text += question;

            Size = new Size(800, count * 40 + 110);
            pnlAnswer.Size = new Size(800, count * 40 + 10);

            string[] texts = choices.Split(',');
            for(int i = 0; i < count; i++)
            {
                RadioButton rb = new RadioButton
                {
                    Location = new Point(30, i * 40 + 10),
                    AutoSize = false,
                    Size = new Size(700, 30),
                    Font = new Font("Gulim", 14F),
                    Text = texts[i],
                    Tag = i + 1,
                    TabStop = false
                };
                pnlAnswer.Controls.Add(rb);
            }

            _choiceType = 1;
        }

        public void CreateChoiceMultiple(string question, int count, string chioces)
        {
            lblQuestion.Text += question;

            this.Size = new Size(800, count * 40 + 110);
            pnlAnswer.Size = new Size(800, count * 40 + 10);

            string[] texts = chioces.Split(',');
            for (int i = 0; i < count; i++)
            {
                CheckBox cb = new CheckBox();
                cb.Location = new Point(30, i * 40 + 10);
                cb.AutoSize = false;
                cb.Size = new Size(700, 30);
                cb.Font = new Font("Gulim", 14F);
                cb.Text = texts[i];
                cb.Tag = i + 1;
                cb.TabStop = false;
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
