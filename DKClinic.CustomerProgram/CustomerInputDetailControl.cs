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
    public partial class CustomerInputDetailControl : BaseUC
    {
        private void ModifyLock(bool mode) // 수정잠금기능 함수
        {
            if (mode == true)
            {
                txbName.ReadOnly = true;
                txbBirthdate.ReadOnly = true;
                txbCellphone.ReadOnly = true;
                rbtMale.Enabled = false;
                rbtFemale.Enabled = false;
            }
            else if (mode == false)
            {
                txbName.ReadOnly = false;
                txbBirthdate.ReadOnly = false;
                txbCellphone.ReadOnly = false;
                rbtMale.Enabled = true;
                rbtFemale.Enabled = true;
            }
        }

        private void InputItemSend ()
        {
                CustomerDepartmentChoiceControl ctmDepChoice = new CustomerDepartmentChoiceControl(); // create ctmDepChoice obj

                //입력값 클래스로 넘기기
                customer.Name = txbName.Text;
                customer.Birthdate = txbBirthdate.Text;
                customer.Cellphone = txbCellphone.Text;

                if (rbtMale.Checked == true) // 남성:1
                    customer.GenderID = 1;
                else if (rbtFemale.Checked == true) // 여성:2
                    customer.GenderID = 2;

                OnctmDetail(customer, ctmDepChoice); //이벤트 생성
        } // 입력값 전달 함수

        private void BirthdateValidationCheck(string date)
        {
            int transint = Convert.ToInt32(date);
            //if(transint)
        }

        public CustomerInputDetailControl()
        {
            InitializeComponent();
        }


        public CustomerInputDetailControl(Customer returnedcustomer)
        {
            InitializeComponent();

            customer = returnedcustomer;
            // 초기 화면출력
            txbName.Text = customer.Name; // 이름 띄우기
            txbBirthdate.Text = customer.Birthdate; // 생년월일 띄우기

            if (customer.CustomerID != 0) // 회원
            {
                //수정기능 잠금
                ModifyLock(true);

                //기존 데이터 load
                txbCellphone.Text = customer.Cellphone;
                
                if(customer.GenderID == 1) // genderid 1이면 남자
                {
                    rbtMale.Checked = true;
                    rbtFemale.Checked = false;
                }
                else if(customer.GenderID == 2) //genderid 2면 여자
                {
                    rbtMale.Checked = false;
                    rbtFemale.Checked = true;
                }
                
            }
            else // 비회원일때
            {
                //작성기능 열림
                ModifyLock(false);
            }
        }
        
        public Customer customer { get; set; } 
        
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (customer.CustomerID == 0) // 회원이 아닐때 수정 내용 확인 msgbox 팝업
            {
                if (WinformUtility.AskSure("입력한 내용이 맞습니까?")) //확인 msgbox
                {
                    //if () //유효성 검사 
                    //{
                    //
                    //}
                    //InputItemSend();
                }
            }
            else //회원일때는 팝업 없이 전달
            {
                InputItemSend();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CustomerLoginControl customerlogin = new CustomerLoginControl();

            //MessageBox.Show($"Canceled");
            OnbtnCancelClicked(customerlogin);

            // 이전 화면으로 돌아가는 새로운 이벤트 추가
        }

        //customer class와 다음 컨트롤 값 넘기는 이벤트 생성코드
        #region ctmDetail event things for C# 3.0
        public event EventHandler<ctmDetailEventArgs> ctmDetail;

        protected virtual void OnctmDetail(ctmDetailEventArgs e)
        {
            if (ctmDetail != null)
                ctmDetail(this, e);
        }

        private ctmDetailEventArgs OnctmDetail(Data.Customer refCustomerClass, CustomerDepartmentChoiceControl refCtmDepChoice)
        {
            ctmDetailEventArgs args = new ctmDetailEventArgs(refCustomerClass, refCtmDepChoice);
            OnctmDetail(args);

            return args;
        }

        private ctmDetailEventArgs OnctmDetailForOut()
        {
            ctmDetailEventArgs args = new ctmDetailEventArgs();
            OnctmDetail(args);

            return args;
        }

        public class ctmDetailEventArgs : EventArgs
        {
            public Data.Customer RefCustomerClass { get; set; }
            public CustomerDepartmentChoiceControl RefCtmDepChoice { get; set; }

            public ctmDetailEventArgs()
            {
            }

            public ctmDetailEventArgs(Data.Customer refCustomerClass, CustomerDepartmentChoiceControl refCtmDepChoice)
            {
                RefCustomerClass = refCustomerClass;
                RefCtmDepChoice = refCtmDepChoice;
            }
        }
        #endregion
    }
}
