using DKClinic.Data;
using System;
using System.Windows.Forms;

namespace DKClinic.EmployeeProgram
{
    public partial class MainForm : Form
    {
        public Employee ConnectedEmployee { get; set; }

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
            EmployeeLoginControl employeeLoginControl = new EmployeeLoginControl();
            OpenLoginControl(employeeLoginControl);
        }

        // EmployeeLoginControl 로드
        private void OpenLoginControl(EmployeeLoginControl employeeLoginControl)
        {
            // 처음 시작시에는 Top, Bottom툴바 출력 안하게
            pnlTop.Visible = false;
            pnlBottom.Visible = false;

            // 시작 화면인 로그인 화면 출력
            employeeLoginControl.LoginToFunction += EmployeeLoginControl_LoginToFunction;
            CallUserControl(employeeLoginControl);
        }

        // EmployeeLoginControl에서 EmployeeSelectFunctionControl을 로드하는 이벤트 핸들러
        private void EmployeeLoginControl_LoginToFunction(object sender, EmployeeLoginControl.LoginToFunctionEventArgs e)
        {
            // Top, Bottom툴바 출력
            pnlTop.Visible = true;
            pnlBottom.Visible = true;

            // 직원 정보를 저장하자
            ConnectedEmployee = e.Employee;

            // 하단에 접속된 직원 이름 출력
            ConnectedEmployee.DepartmentName = Dao.Department.GetByPK(ConnectedEmployee.DepartmentID).Name;
            ConnectedEmployee.PositionName = Dao.Position.GetByPK(ConnectedEmployee.PositionID).Name;
            lblStatus.Text = $"{ConnectedEmployee.DepartmentName} {ConnectedEmployee.PositionName} {ConnectedEmployee.Name}님 로그인중...";

            // 이벤트 생성되면 핸들러 추가하기
            e.EmpsltfunControl.SelectToFunction += EmployeeSelectFunctionControl_SelectToFunction;
            CallUserControl(e.EmpsltfunControl);
        }

        // EmployeeSelectFunctionControl에서 선택된 컨트롤을 로드하는 이벤트 핸들러
        private void EmployeeSelectFunctionControl_SelectToFunction(object sender, EmployeeSelectFunctionControl.SelectToFunctionEventArgs e)
        {
            e.BaseUC.btnCancelClicked += BaseUC_btnCancelClicked;
            CallUserControl(e.BaseUC);
        }

        // Manage 컨트롤에서 뒤로가기 버튼을 누를 시 작동하는 이벤트 핸들러
        private void BaseUC_btnCancelClicked(object sender, BaseUC.btnCancelClickedEventArgs e)
        {
            ((EmployeeSelectFunctionControl)e.BaseUC).SelectToFunction += EmployeeSelectFunctionControl_SelectToFunction;
            CallUserControl(e.BaseUC);
        }

        // 패널 pnlMain에 입력받은 컨트롤 로드
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
            ConnectedEmployee = null;

            EmployeeLoginControl employeeLoginControl = new EmployeeLoginControl();
            OpenLoginControl(employeeLoginControl);
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
