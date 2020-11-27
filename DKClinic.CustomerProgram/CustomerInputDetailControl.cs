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
        // 수정잠금기능 함수
        private void ModifyLock(int customerID) 
        {
            if (customerID != 0) // 회원
            {
                txbName.ReadOnly = true;
                txbBirthdate.ReadOnly = true;
                txbCellphone.ReadOnly = true;
                rbtMale.Enabled = false;
                rbtFemale.Enabled = false;
            }
            else if (customerID == 0) // 비회원
            {
                txbName.ReadOnly = true;
                txbBirthdate.ReadOnly = true;
                txbCellphone.ReadOnly = false;
                rbtMale.Enabled = true;
                rbtFemale.Enabled = true;
            }
            else if (customerID == 999999999) // 모두 수정 가능
            {
                txbName.ReadOnly = false;
                txbBirthdate.ReadOnly = false;
                txbCellphone.ReadOnly = false;
                rbtMale.Enabled = true;
                rbtFemale.Enabled = true;
            }
        }

        // 입력값 전달 함수
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

                OnDetailToDepartment(customer, ctmDepChoice); //이벤트 생성
        }

        public CustomerInputDetailControl()
        {
            InitializeComponent();
            Title = "추가정보 입력";
        }


        public CustomerInputDetailControl(Customer returnedcustomer) : this()
        {
            customer = returnedcustomer;
            // 초기 화면출력
            txbName.Text = customer.Name; // 이름 띄우기
            txbBirthdate.Text = customer.Birthdate; // 생년월일 띄우기

            if (customer.CustomerID != 0) // 회원
            {
                //수정기능 잠금
                ModifyLock(customer.CustomerID);

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
                //비회원 작성기능 열림
                ModifyLock(customer.CustomerID);
            }
        }
        
        public Customer customer { get; set; } 
        
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (customer.CustomerID == 0) // 회원이 아닐때 수정 내용 확인 msgbox 팝업
            {
                if (WinformUtility.AskSure("입력한 내용이 맞습니까?")) //확인 msgbox
                {
                    //입력 유효성 검사
                    if (WinformUtility.IsCellphoneValidationError(txbCellphone.Text))
                        return;
                    if (WinformUtility.IsBirthdateValidationError(txbBirthdate.Text))
                        return;
                    else if (IsAnyBlankGenderAndCellphone(rbtMale, rbtFemale, txbCellphone.Text))
                        return;
                    InputItemSend();
                }
            }
            else //회원일때는 팝업 없이 전달
            {
                InputItemSend();
            }
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CustomerLoginControl customerlogin = new CustomerLoginControl();

            OnbtnCancelClicked(customerlogin);

            // 이전 화면으로 돌아가는 새로운 이벤트 추가
        }

        //customer class와 다음 컨트롤 값 넘기는 이벤트 생성코드
        #region DetailToDepartment event things for C# 3.0
        public event EventHandler<DetailToDepartmentEventArgs> ctmDetail;

        protected virtual void OnDetailToDepartment(DetailToDepartmentEventArgs e)
        {
            if (ctmDetail != null)
                ctmDetail(this, e);
        }

        private DetailToDepartmentEventArgs OnDetailToDepartment(Data.Customer refCustomerClass, CustomerDepartmentChoiceControl refCtmDepChoice)
        {
            DetailToDepartmentEventArgs args = new DetailToDepartmentEventArgs(refCustomerClass, refCtmDepChoice);
            OnDetailToDepartment(args);

            return args;
        }

        private DetailToDepartmentEventArgs OnDetailToDepartmentForOut()
        {
            DetailToDepartmentEventArgs args = new DetailToDepartmentEventArgs();
            OnDetailToDepartment(args);

            return args;
        }

        public class DetailToDepartmentEventArgs : EventArgs
        {
            public Data.Customer RefCustomerClass { get; set; }
            public CustomerDepartmentChoiceControl RefCtmDepChoice { get; set; }

            public DetailToDepartmentEventArgs()
            {
            }

            public DetailToDepartmentEventArgs(Data.Customer refCustomerClass, CustomerDepartmentChoiceControl refCtmDepChoice)
            {
                RefCustomerClass = refCustomerClass;
                RefCtmDepChoice = refCtmDepChoice;
            }
        }
        #endregion

    }
}
