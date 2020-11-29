using DKClinic.Data;
using System;
using System.Windows.Forms;

namespace DKClinic.CustomerProgram
{
    public partial class MainForm : Form
    {
        public Customer ConnectedCustomer { get; set; }
        public Questionnare CreatedQuestionnare { get; set; }
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

        // CustomerLoginControl 로드
        private void OpenLoginControl(CustomerLoginControl customerLoginControl)
        {
            // 처음 시작시에는 Top, Bottom툴바 출력 안하게
            pnlTop.Visible = false;
            pnlBottom.Visible = false;

            // 시작 화면인 로그인 화면 출력
            customerLoginControl.LoginToDetail += CustomerLoginControl_LoginToDetail;
            CallUserControl(customerLoginControl);
        }

        // CustomerLoginControl에서 CustomerInputDetailControl 로드하는 이벤트 핸들러
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

        // CustomerInputDetailControl에서 Cancel로 CustomerLoginControl 로드하는 이벤트 핸들러
        private void CustomerInputDetailControl_btnCancelClicked(object sender, BaseUC.btnCancelClickedEventArgs e)
        {
            OpenLoginControl((CustomerLoginControl)e.BaseUC);
        }

        // CustomerInputDetailControl에서 CustomDepartmentChoiceControl 로드하는 이벤트 핸들러
        private void CustomerInputDetailControl_ctmDetail(object sender, CustomerInputDetailControl.DetailToDepartmentEventArgs e)
        {
            ConnectedCustomer = e.RefCustomerClass;

            // CustomerDepartmentChoiceControl 이벤트 핸들러 등록
            e.RefCtmDepChoice.DepartmentToQuestionnare += CustomerDepartmentChoiceControl_DepartmentToQuestionnare;

            // departmentChoice 불러오기
            CallUserControl(e.RefCtmDepChoice);
        }

        // CustomerDepartmentChoiceControl에서 CustomerQuestionnareControl 로드하는 이벤트 핸들러
        private void CustomerDepartmentChoiceControl_DepartmentToQuestionnare(object sender, CustomerDepartmentChoiceControl.DepartmentToQuestionnareEventArgs e)
        {
            CreatedQuestionnare = new Questionnare { Customer = ConnectedCustomer };
            CreatedQuestionnare.DepartmentID = e.DepartmentID;

            // CustomerDepartmentChoiceControl 이벤트 핸들러 등록
            e.CustQuestionnare.QuestionnareConfirm += CustomerQuestionnareControl_QuestionnareConfirm;

            // departmentChoice 불러오기
            CallUserControl(e.CustQuestionnare);
        }

        // CustomerQuestionnareControl에서 작성 완료 이벤트 및 초기 화면으로 돌아가는 이벤트 핸들러
        private void CustomerQuestionnareControl_QuestionnareConfirm(object sender, CustomerQuestionnareControl.QuestionnareConfirmEventArgs e)
        {
            // 데이터 입력하기
            using (var context = DKClinicEntities.Create())
            {
                // Customer
                if (ConnectedCustomer.CustomerID == 0)
                    context.Customers.Add(ConnectedCustomer);

                // Questionnare
                CreatedQuestionnare.Date = DateTime.Now;
                context.Questionnares.Add(CreatedQuestionnare);

                // Response
                foreach(Response item in e.Responses)
                {
                    Response response = new Response { Questionnare = CreatedQuestionnare };
                    response.Answer = item.Answer;
                    response.QuestionID = item.QuestionID;
                    context.Responses.Add(response);
                }

                context.SaveChanges();
            }

            // 초기 화면으로 돌아가기
            btnHome.PerformClick();
        }

        // 유저 컨트롤을 패널 pnlMain에 로드
        public void CallUserControl(BaseUC control)
        {
            if (MainControl.Count > 0)
                MainControl.Clear();

            control.Dock = DockStyle.Fill;
            MainControl.Add(control);
            lblTitle.Text = control.Title;
        }

        // 상단 패널(툴바) 홈버튼 클릭 이벤트
        private void btnHome_Click(object sender, EventArgs e)
        {
            // 초기 화면으로 돌아가기
            ConnectedCustomer = null;
            CreatedQuestionnare = new Questionnare();

            CustomerLoginControl customerLoginControl = new CustomerLoginControl();
            OpenLoginControl(customerLoginControl);
        }

        // 상단 패널(툴바) 종료 버튼 클릭 이벤트
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // 하단 패널(툴바) 시간 표시하는 타이머
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }
    }
}
