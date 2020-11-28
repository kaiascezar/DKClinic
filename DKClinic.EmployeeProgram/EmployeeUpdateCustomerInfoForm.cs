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
    public partial class EmployeeUpdateCustomerInfoForm : Form
    {
        //이름, 생년월일 tbx 중 빈칸 있을 시 입력요청 메세지 박스 호출, 생년월일 유효성 검사
        private bool IsAnyBlankTextbox(string text1, string text2)
        {
            //입력값 없을 경우
            if (text1 == "" || text2 == "")
            {
                MessageBox.Show("항목을 입력해주세요", "Warning");
                return true;
            }

            return false;
        }

        //성별과 연락처 빈칸일 때 오류 메세지 출력
        private bool IsAnyBlankGenderAndCellphone(RadioButton rbtMale, RadioButton rbtFemale, string text)
        {
            if ((rbtMale.Checked == false && rbtFemale.Checked == false) || txbCellphone.Text == "")
            {
                MessageBox.Show("항목을 입력해주세요", "Warning");
                return true;
            }
            else
                return false;
        }

        private void CurrentStatus(Customer customer)
        {
            ChangedCustomerInfo = customer;
            txbName.Text = customer.Name;
            txbBirthdate.Text = customer.Birthdate;
            txbCellphone.Text = customer.Cellphone;
            if (customer.GenderID == 1)
            {
                rbtMale.Checked = true;
                rbtFemale.Checked = false;
            }
            else if (customer.GenderID == 2)
            {
                rbtMale.Checked = false;
                rbtFemale.Checked = true;
            }
        }

        public EmployeeUpdateCustomerInfoForm(Customer customer)
        {
            InitializeComponent();
            CurrentStatus(customer);
        }
        private Customer ChangedCustomerInfo { get; set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (WinformUtility.IsBirthdateValidationError(txbBirthdate.Text))
                return;
            if (WinformUtility.IsCellphoneValidationError(txbCellphone.Text))
                return;
            if (IsAnyBlankTextbox(txbName.Text, txbBirthdate.Text))
                return;
            else if (IsAnyBlankGenderAndCellphone(rbtMale, rbtFemale, txbCellphone.Text))
                return;

            ChangedCustomerInfo.Name = txbName.Text;
            ChangedCustomerInfo.Birthdate = txbBirthdate.Text;
            ChangedCustomerInfo.Cellphone = txbCellphone.Text;
            if(rbtMale.Checked == true)
            {
                ChangedCustomerInfo.GenderID = 1;
            }
            else if (rbtFemale.Checked == true)
            {
                ChangedCustomerInfo.GenderID = 2;
            }

            Dao.Customer.Update(ChangedCustomerInfo);
            MessageBox.Show($"수정이 완료되었습니다.");
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //이름에는 숫자 입력 불가능
        private void txbName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!(Char.IsLetter(e.KeyChar)) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        //생년월일에는 숫자만 입력 가능
        private void txbBirthdate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        //연락처에는 숫자만 입력 가능
        private void txbCellphone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar)) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
    }
}

