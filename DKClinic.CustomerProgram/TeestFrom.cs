using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKClinic.CustomerProgram
{
    public partial class TeestFrom : Form
    {
        public TeestFrom()
        {
            InitializeComponent();
            CustomerQuestionnareControl q = new CustomerQuestionnareControl();
            Controls.Add(q);
            q.Dock = DockStyle.Fill;

            MultipleChoiceControl question = new MultipleChoiceControl();
            question.CreateChoiceSingle(6, "1번,2번,3번,4번,5번,6번");
            q.AddQuestionControl(question);

            MultipleChoiceControl question2 = new MultipleChoiceControl();
            question2.CreateChoiceMultiple(6, "1번,2번,3번,4번,5번,6번");
            q.AddQuestionControl(question2);

            ShortAnswerControl question3 = new ShortAnswerControl();
            question3.CreateAnswer();
            q.AddQuestionControl(question3);
        }
    }
}
