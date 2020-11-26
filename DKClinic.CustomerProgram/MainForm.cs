using DKClinic.Data;
using System;
using System.Windows.Forms;

namespace DKClinic.CustomerProgram
{
    public partial class MainForm : Form
    {
        public Customer ConnectedCustomer { get; set; }
        public Questionnare CreatedQuestionnare { get; set; } = new Questionnare();
        public Control.ControlCollection MainControl { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode)
                return;

            // 가운데 패널의 컨트롤 컬렉터의 별칭을 지정
            MainControl = pnlMain.Controls;

            // 시작 화면인 로그인 화면 출력
            CustomerLoginControl customerLoginControl = new CustomerLoginControl();
            OpenLoginControl(customerLoginControl);
        }

        private void OpenLoginControl(CustomerLoginControl customerLoginControl)
        {
            // 처음 시작시에는 Top, Bottom툴바 출력 안하게
            pnlTop.Visible = false;
            pnlBottom.Visible = false;

            // 시작 화면인 로그인 화면 출력
            customerLoginControl.LoginToDetail += CustomerLoginControl_LoginToDetail;
            CallUserControl(customerLoginControl);
        }

        private void CustomerLoginControl_LoginToDetail(object sender, CustomerLoginControl.LoginToDetailEventArgs e)
        {
            // 고객 정보를 저장하자
            ConnectedCustomer = e.Customer;

            // Top, Bottom툴바 출력
            pnlTop.Visible = true;
            pnlBottom.Visible = true;

            // 하단에 접속된 고객 이름 출력
            lblStatus.Text = "고객 " + ConnectedCustomer.Name + "님 로그인중...";

            // CustomerInputDetailControl 이벤트 핸들러 등록
            e.CtmInputDetail.ctmDetail += CustomerInputDetailControl_ctmDetail;
            e.CtmInputDetail.btnCancelClicked += CustomerInputDetailControl_btnCancelClicked;
            CallUserControl(e.CtmInputDetail);
        }

        private void CustomerInputDetailControl_btnCancelClicked(object sender, BaseUC.btnCancelClickedEventArgs e)
        {
            OpenLoginControl((CustomerLoginControl)e.BaseUC);
        }

        private void CustomerInputDetailControl_ctmDetail(object sender, CustomerInputDetailControl.ctmDetailEventArgs e)
        {
            ConnectedCustomer = e.RefCustomerClass;

            // CustomerDepartmentChoiceControl 이벤트 핸들러 등록
            e.RefCtmDepChoice.DepartmentToQuestionnare += CustomerDepartmentChoiceControl_DepartmentToQuestionnare;

            // departmentChoice 불러오기
            CallUserControl(e.RefCtmDepChoice);
        }

        private void CustomerDepartmentChoiceControl_DepartmentToQuestionnare(object sender, CustomerDepartmentChoiceControl.DepartmentToQuestionnareEventArgs e)
        {
            CreatedQuestionnare.DepartmentID = e.DepartmentID;

            // CustomerDepartmentChoiceControl 이벤트 핸들러 등록
            e.CustQuestionnare.QuestionnareConfirm += CustomerQuestionnareControl_QuestionnareConfirm;

            // departmentChoice 불러오기
            CallUserControl(e.CustQuestionnare);
        }

        private void CustomerQuestionnareControl_QuestionnareConfirm(object sender, CustomerQuestionnareControl.QuestionnareConfirmEventArgs e)
        {
            int customerID;

            // CustomerID 구하기
            if (ConnectedCustomer.CustomerID == 0)
                customerID = Dao.Customer.GetMaxKey() + 1;
            else
                customerID = ConnectedCustomer.CustomerID;

            // questionnare 테이블에 CustomerID, Date저장
            CreatedQuestionnare.CustomerID = customerID;
            CreatedQuestionnare.Date = DateTime.Now;

            // QuestionnareID 구하기
            int questionnareID = Dao.Questionnare.GetMaxKey() + 1;

            // 데이터 입력하기
            using (var context = DKClinicEntities.Create())
            {
                if (ConnectedCustomer.CustomerID == 0)
                    context.Customers.Add(ConnectedCustomer);
                context.Questionnares.Add(CreatedQuestionnare);
                foreach(Response item in e.Responses)
                {
                    item.QuestionnareID = questionnareID;
                    context.Responses.Add(item);
                }
                context.SaveChanges();
            }

            // 초기 화면으로 돌아가기
            btnHome.PerformClick();
        }

        public void CallUserControl(BaseUC control)
        {
            if (MainControl.Count > 0)
                MainControl.Clear();

            control.Dock = DockStyle.Fill;
            MainControl.Add(control);
            lblTitle.Text = control.Title;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            // 초기 화면으로 돌아가기
            ConnectedCustomer = null;
            CreatedQuestionnare = null;

            CustomerLoginControl customerLoginControl = new CustomerLoginControl();
            OpenLoginControl(customerLoginControl);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }
    }
}
