using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKClinic.MainScene
{
    public static class WinformUtility
    {
        public static bool AskSure(string question)
        {
            return MessageBox.Show(question, "Question",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes;
        }

        public static bool AskDelete()
        {
            return false;
        }
    }
}
