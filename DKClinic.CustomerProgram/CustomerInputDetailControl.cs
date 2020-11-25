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

        public CustomerInputDetailControl()
        {
            InitializeComponent();
            
            refCustomerClass = new Data.Customer(); // create customer obj
            int customerID = refCustomerClass.CustomerID;
            MessageBox.Show($"customID: {customerID}");


            // 초기 화면출력
            txbName.Text = refCustomerClass.Name; // 이름 띄우기
            txbBirthdate.Text = refCustomerClass.Birthdate; // 생년월일 띄우기

            customerID = 0;

            if (customerID == 0) // 회원일때
            {
                //수정기능 잠금
                ModifyLock(true);

                //기존 데이터 load
                txbName.Text = refCustomerClass.Name;
                txbBirthdate.Text = refCustomerClass.Birthdate;
                txbCellphone.Text = refCustomerClass.Cellphone;
                
                if(refCustomerClass.GenderID == 1) // genderid 1이면 남자
                {
                    rbtMale.Checked = true;
                    rbtFemale.Checked = false;
                }
                else if(refCustomerClass.GenderID == 2) //genderid 2면 여자
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
        
        Data.Customer refCustomerClass; 
        
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            ctmDepChoice ctmDepChoice1 = new ctmDepChoice(); // create ctmDepChoice obj

            if (MessageBox.Show("입력하신 내용이 맞습니까?","내용확인",MessageBoxButtons.YesNo) == DialogResult.Yes)//확인 msgbox
            {
                OnctmDetail(refCustomerClass, ctmDepChoice1); //이벤트 생성
                //ctmDepChoice1.Show();
                MessageBox.Show($"ctmDepChoice1.Show()");
               
            }
            else
            {
                MessageBox.Show($"Canceled");
            }           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Canceled");
        }



        //이벤트 생성코드
        #region ctmDetail event things for C# 3.0
        public event EventHandler<ctmDetailEventArgs> ctmDetail;

        protected virtual void OnctmDetail(ctmDetailEventArgs e)
        {
            if (ctmDetail != null)
                ctmDetail(this, e);
        }

        private ctmDetailEventArgs OnctmDetail(Data.Customer refCustomerClass, ctmDepChoice refCtmDepChoice)
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
            public ctmDepChoice RefCtmDepChoice { get; set; }

            public ctmDetailEventArgs()
            {
            }

            public ctmDetailEventArgs(Data.Customer refCustomerClass, ctmDepChoice refCtmDepChoice)
            {
                RefCustomerClass = refCustomerClass;
                RefCtmDepChoice = refCtmDepChoice;
            }
        }
        #endregion

    }
}
