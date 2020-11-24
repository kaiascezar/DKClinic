using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKClinic.Customer
{
    public partial class MultipleChoice : BaseQuestion
    {
        public MultipleChoice()
        {
            InitializeComponent();
        }

        public void CreateChoiceSingle(int count, string text)
        {
            string[] texts = text.Split(',');
            for(int i = 0; i < count; i++)
            {
                RadioButton rb = new RadioButton();
                rb.Location = new Point(i * 120 + 30, 10);
                rb.AutoSize = false;
                rb.Size = new Size(80, 30);
                rb.Font = new Font("Gulim", 14F);
                rb.Text = texts[i];
                pnlAnswer.Controls.Add(rb);
            }
        }

        public void CreateChoiceMultiple(int count, string text)
        {
            string[] texts = text.Split(',');
            for (int i = 0; i < count; i++)
            {
                CheckBox cb = new CheckBox();
                cb.Location = new Point(i * 120 + 30, 10);
                cb.AutoSize = false;
                cb.Size = new Size(80, 30);
                cb.Font = new Font("Gulim", 14F);
                cb.Text = texts[i];
                pnlAnswer.Controls.Add(cb);
            }
        }
    }
}
