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
    public partial class EmployeeUpdateInfoForm : Form
    {
        private Employee employee { get; set; }
        public EmployeeUpdateInfoForm()
        {
            InitializeComponent();
            employee = new Employee();
        }

        public EmployeeUpdateInfoForm(Employee selectedemployee) : this()
        {
            txbName.Text = selectedemployee.Name;
            txbBirthdate.Text = selectedemployee.Birthdate;
            if (selectedemployee.GenderID == 1)
                rbtMale.Checked = true;
            else if (selectedemployee.GenderID == 2)
                rbtFemale.Checked = true;
            txbCellphone.Text = selectedemployee.Cellphone;
            txbPosition.Text = selectedemployee.PositionName;
            txbDepartment.Text = selectedemployee.DepartmentName;

            employee = selectedemployee;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //입력 유효성 검사
            if (IsValidationError(txbName.Text, txbBirthdate.Text, txbCellphone.Text, txbPosition.Text, txbDepartment.Text))
                return;
            else if (WinformUtility.IsBirthdateValidationError(txbBirthdate.Text))
                return;
            else if (WinformUtility.IsCellphoneValidationError(txbCellphone.Text))
                return;
            //성별 체크 안되있을시
            if (rbtMale.Checked == false && rbtFemale.Checked == false)
            {
                MessageBox.Show("항목을 입력해주세요", "Warning");
                return;
            }

            employee.Name = txbName.Text;
            employee.Birthdate = txbBirthdate.Text;
            if (rbtMale.Checked == true)
                employee.GenderID = 1;
            else if (rbtFemale.Checked == true)
                employee.GenderID = 2;
            employee.Cellphone = txbCellphone.Text;
            SetPosition(txbPosition.Text);          // 직급 ID 입력
            SetDepartment(txbDepartment.Text);      // 진료과 ID 입력

            if (employee.EmployeeID == 0)     //추가
            {
                employee.Password = "password";    //신규 생성 default password
                MessageBox.Show("신규 직원이 추가되었습니다.");
                Dao.Employee.Insert(employee);
            }
            else                              //수정
            {
                MessageBox.Show("직원 정보가 수정되었습니다.");
                Dao.Employee.Update(employee);
            }
            
            Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool IsValidationError(string name, string birthdate, string cellphone, string position, string department)
        {
            //입력값 없을 경우
            if (name == "" || birthdate == "" || cellphone == "" || position == "" || department == "")
            {
                MessageBox.Show("항목을 입력해주세요", "Warning");
                return true;
            }
            if (position != "관리자" && position != "의사" && position != "간호사")
            {
                MessageBox.Show("존재하지 않는 직급입니다.", "Warning");
                return true;
            }
            if (department != "내과" && department != "신경과" && department != "피부과" && department != "가정의학과")
            {
                MessageBox.Show("존재하지 않는 진료과입니다.", "Warning");
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
        private void SetPosition(string text)
        {
            if (text == "관리자")
                employee.PositionID = 1;
            else if (text == "의사")
                employee.PositionID = 2;
            else if (text == "간호사")
                employee.PositionID = 3;
        }
        private void SetDepartment(string text)
        {
            if (text == "내과")
                employee.DepartmentID = 1;
            else if (text == "신경과")
                employee.DepartmentID = 2;
            else if (text == "피부과")
                employee.DepartmentID = 3;
            else if (text == "가정의학과")
                employee.DepartmentID = 4;
        }
    }
}
