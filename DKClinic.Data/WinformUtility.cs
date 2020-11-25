using System.Windows.Forms;

namespace DKClinic.Data
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
