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

namespace DKClinic.CustomerProgram
{
    public partial class CustomerLoginControl : BaseUC
    {
        public CustomerLoginControl()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //입력 유효성 검사
            if (IsAnyBlankTextbox(txbName.Text, txbBirthdate.Text))
                return;
            if (WinformUtility.IsBirthdateValidationError(txbBirthdate.Text))
                return;
            //Customer 클래스에 입력값 임시 저장
            Customer customer = Dao.Customer.Find(txbName.Text, txbBirthdate.Text);

            //신규 회원일경우
            if (customer == null)
            {
                customer = new Customer();
                customer.Name = txbName.Text;
                customer.Birthdate = txbBirthdate.Text;
            }
            
            //다음 유저컨트롤 전달용
            CustomerInputDetailControl ctmInputDetail = new CustomerInputDetailControl(customer);

            if (customer.CustomerID != 0)
            {
                MessageBox.Show("방문기록이 있습니다.");                 //기존 회원
            }
            else
            {
                MessageBox.Show("환영합니다. 처음 방문하셨습니다.");      //신규 회원
            }

            //이벤트 발생
            OnLoginToDetail(customer, ctmInputDetail);
        }

        #region LoginToDetail event things for C# 3.0
        public event EventHandler<LoginToDetailEventArgs> LoginToDetail;

        protected virtual void OnLoginToDetail(LoginToDetailEventArgs e)
        {
            if (LoginToDetail != null)
                LoginToDetail(this, e);
        }

        private LoginToDetailEventArgs OnLoginToDetail(Customer customer, CustomerInputDetailControl ctmInputDetail)
        {
            LoginToDetailEventArgs args = new LoginToDetailEventArgs(customer, ctmInputDetail);
            OnLoginToDetail(args);

            return args;
        }

        private LoginToDetailEventArgs OnLoginToDetailForOut()
        {
            LoginToDetailEventArgs args = new LoginToDetailEventArgs();
            OnLoginToDetail(args);

            return args;
        }

        public class LoginToDetailEventArgs : EventArgs
        {
            public Customer Customer { get; set; }
            public CustomerInputDetailControl CtmInputDetail { get; set; }

            public LoginToDetailEventArgs()
            {
            }

            public LoginToDetailEventArgs(Customer customer, CustomerInputDetailControl ctmInputDetail)
            {
                Customer = customer;
                CtmInputDetail = ctmInputDetail;
            }
        }
        #endregion
        //취소버튼 = 입력칸초기화
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txbName.Clear();
            txbBirthdate.Clear();
        }
        //입력값이 없는 경우
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
    }
}
