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
        //생년월일 빈칸일 시 메세지 출력
        private void ValidationFailMessage()
        {
            MessageBox.Show("생년월일을 정확하게 입력해 주세요", "Warning");
        }

        //이름, 생년월일 tbx 중 빈칸 있을 시 입력요청 메세지 박스 호출, 생년월일 유효성 검사
        private bool IsValidationError(string text1, string text2)
        {
            //입력값 없을 경우
            if (text1 == "" || text2 == "")
            {
                MessageBox.Show("항목을 입력해주세요", "Warning");
                return true;
            }

            if (text2.Length < 6)
            {
                ValidationFailMessage();
                return true;
            }

            int month = int.Parse(text2) % 10000 / 100;
            int day = int.Parse(text2) % 100;

            //월,일이 틀릴 경우
            if (month < 1 || month > 12 || day < 1 || day > 31)
            {
                ValidationFailMessage();
                return true;
            }
            //일이 틀릴 경우
            if (month % 2 == 0 && month < 7)
            {
                if (month == 2)
                {
                    if (day > 28)
                    {
                        ValidationFailMessage();
                        return true;
                    }
                }
                else if (day > 30)
                {
                    ValidationFailMessage();
                    return true;
                }
            }
            else if (month == 9 && month == 11)
            {
                if (day > 30)
                {
                    ValidationFailMessage();
                    return true;
                }
            }

            return false;
        }

        //성별과 연락처 빈칸일 때 오류 매새지 출력
        private bool IsBlankGenderAndCellphone(RadioButton rbtMale, RadioButton rbtFemale, string text)
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
            if (IsValidationError(txbName.Text, txbBirthdate.Text))
                return;
            else if (IsBlankGenderAndCellphone(rbtMale, rbtFemale, txbCellphone.Text))
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
    }
}
