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
    public partial class TeestFrom : Form
    {
        public TeestFrom()
        {
            InitializeComponent();
            ctmQuestionnare q = new ctmQuestionnare();
            Controls.Add(q);
            q.Dock = DockStyle.Fill;

            MultipleChoice question = new MultipleChoice();
            question.CreateChoiceSingle(6, "1번,2번,3번,4번,5번,6번");
            q.AddQuestionControl(question);

            MultipleChoice question2 = new MultipleChoice();
            question2.CreateChoiceMultiple(6, "1번,2번,3번,4번,5번,6번");
            q.AddQuestionControl(question2);

            ShortAnswer question3 = new ShortAnswer();
            question3.CreateAnswer();
            q.AddQuestionControl(question3);
        }
    }
}
