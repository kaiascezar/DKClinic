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
    public partial class EmployeeLoginControl : BaseUC
    {
        public EmployeeLoginControl()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //입력 유효성 검사
            if (IsValidationError(txbName.Text, txbPassword.Text))
               return;

            //Employee 클래스에 입력값 임시 저장
            Employee employee = Dao.Employee.GetByName(txbName.Text);
            
            if (employee == null)   //미등록 ID 입력시
            {
                MessageBox.Show("유효하지 않은 ID를 입력하였습니다.", "Warning");
                return;
            }
            if (employee.Password != txbPassword.Text)  //PW 잘못 입력시
            {
                MessageBox.Show("잘못된 PW를 입력하였습니다.", "Warning");
                return;
            }

            //다음 유저컨트롤 전달용
            EmployeeSelectFunctionControl empsltfunControl = new EmployeeSelectFunctionControl(employee);
            //이벤트 발생
            OnLoginToFunction(employee, empsltfunControl);
        }

        #region LoginToFunction event things for C# 3.0
        public event EventHandler<LoginToFunctionEventArgs> LoginToFunction;

        protected virtual void OnLoginToFunction(LoginToFunctionEventArgs e)
        {
            if (LoginToFunction != null)
                LoginToFunction(this, e);
        }

        private LoginToFunctionEventArgs OnLoginToFunction(Employee employee, EmployeeSelectFunctionControl empsltfunControl)
        {
            LoginToFunctionEventArgs args = new LoginToFunctionEventArgs(employee, empsltfunControl);
            OnLoginToFunction(args);

            return args;
        }

        private LoginToFunctionEventArgs OnLoginToFunctionForOut()
        {
            LoginToFunctionEventArgs args = new LoginToFunctionEventArgs();
            OnLoginToFunction(args);

            return args;
        }

        public class LoginToFunctionEventArgs : EventArgs
        {
            public Employee Employee { get; set; }
            public EmployeeSelectFunctionControl EmpsltfunControl { get; set; }

            public LoginToFunctionEventArgs()
            {
            }

            public LoginToFunctionEventArgs(Employee employee, EmployeeSelectFunctionControl empsltfunControl)
            {
                Employee = employee;
                EmpsltfunControl = empsltfunControl;
            }
        }
        #endregion

        //비밀번호변경버튼 = 변경 새 폼 띄우기
        private void btnChangePw_Click(object sender, EventArgs e)
        {
            EmployeeChangePasswordForm empChangePw = new EmployeeChangePasswordForm();
            empChangePw.ShowDialog();
        }

        //취소소버튼 = 입력값 초기화
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txbName.Clear();
            txbPassword.Clear();
        }
        private bool IsValidationError(string text1, string text2)
        {
            //입력값 없을 경우
            if (text1 == "" || text2 == "")
            {
                MessageBox.Show("항목을 입력해주세요", "Warning");
                return true;
            }

            return false;
        }
    }
}
