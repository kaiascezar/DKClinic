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

        public static bool IsBirthdateValidationError(string birthdate)
        {
            if (birthdate.Length < 6)
            {
                MessageBox.Show("생년월일을 정확하게 입력해 주세요", "Warning");
                return true;
            }

            int month = int.Parse(birthdate) % 10000 / 100;
            int day = int.Parse(birthdate) % 100;

            //월,일이 틀릴 경우
            if (month < 1 || month > 12 || day < 1 || day > 31)
            {
                MessageBox.Show("생년월일을 정확하게 입력해 주세요", "Warning");
                return true;
            }
            //일이 틀릴 경우
            if (month % 2 == 0 && month < 7)
            {
                if (month == 2)
                {
                    if (day > 28)
                    {
                        MessageBox.Show("생년월일을 정확하게 입력해 주세요", "Warning");
                        return true;
                    }
                }
                else if (day > 30)
                {
                    MessageBox.Show("생년월일을 정확하게 입력해 주세요", "Warning");
                    return true;
                }
            }
            else if (month == 9 && month == 11)
            {
                if (day > 30)
                {
                    MessageBox.Show("생년월일을 정확하게 입력해 주세요", "Warning");
                    return true;
                }
            }

            return false;
        }

        public static bool IsCellphoneValidationError(string cellphone)
        {
            if (cellphone.Length < 11)
            {
                MessageBox.Show("전화번호를 양식에 맞게 입력해 주세요", "Warning");
                return true;
            }

            string identifier = cellphone.Substring(0, 3);
            if (identifier != "010")
            {
                MessageBox.Show("전화번호를 양식에 맞게 입력해 주세요", "Warning");
                return true;
            }
            return false;
        }
    }
}
