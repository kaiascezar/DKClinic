using DKClinic.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKClinic.EmployeeProgram
{
    public partial class EmployeeChangePasswordForm : Form
    {
        public EmployeeChangePasswordForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //입력 유효성 검사
            if (IsAnyBlankTextbox(txbName.Text, txbOldPw.Text, txbNewPw.Text, txbNewPwCheck.Text))
                return;

            //Employee 클래스에 입력값 임시 저장
            Employee employee = Dao.Employee.GetByName(txbName.Text);
                
            //미등록 이름 입력시
            if (employee == null)
            {
                MessageBox.Show("유효하지 않은 ID를 입력하였습니다.", "Warning");
                return;
            }
            //기존 암호 불일치시
            if (txbOldPw.Text != employee.Password)
            {
                MessageBox.Show("기존 PW를 잘못 입력하였습니다.", "Warning");
                return;
            }
            //신규 암호 불일치시
            if (txbNewPw.Text != txbNewPwCheck.Text)
            {
                MessageBox.Show("신규 PW가 일치하지 않습니다.", "Warning");
                return;
            }

            MessageBox.Show("비밀번호가 변경되었습니다.");
            employee.Password = txbNewPw.Text;
            Dao.Employee.Update(employee);

            Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool IsAnyBlankTextbox(string text1, string text2, string text3, string text4)
        {
            //입력값 없을 경우
            if (text1 == "" || text2 == "" || text3 == "" || text4 == "")
            {
                MessageBox.Show("항목을 입력해주세요", "Warning");
                return true;
            }

            return false;
        }
        //이름에는 숫자 입력 불가능
        private void txbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar)) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        //암호에는 공백 입력 불가능
        private void txb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }
    }
}
