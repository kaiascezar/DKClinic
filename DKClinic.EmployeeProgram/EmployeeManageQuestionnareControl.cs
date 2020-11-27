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
    public partial class EmployeeManageQuestionnareControl : BaseUC
    {
        public EmployeeManageQuestionnareControl()
        {
            InitializeComponent();
            ReloadGridView();
        }

        public Questionnare CurrentQuestionnare { get; set; }
        public Employee CurrentEmployee { get; }


        //뒤로가기버튼
        private void btnGoBack_Click(object sender, EventArgs e)
        {
            EmployeeSelectFunctionControl employeeSelectFunctionControl = new EmployeeSelectFunctionControl();
            
            OnbtnCancelClicked(employeeSelectFunctionControl);
        }


        //문진표 열람 & 진단서 작성
        private void btnOpenResponse_Click(object sender, EventArgs e)
        {
            CurrentQuestionnare = bdsQuestionnare.Current as Questionnare;
            
            //문진표 열람 & 진단서 작성 폼 호출 및 gridview 내 선택된 값 전달용 변수
            EmployeeCheckResponseDiagnosis employeeModifyQuestionnareForm = new EmployeeCheckResponseDiagnosis(CurrentQuestionnare);
            employeeModifyQuestionnareForm.ShowDialog();
        }

        //삭제버튼
        private void btnDelete_Click(object sender, EventArgs e)
        {
            CurrentQuestionnare = bdsQuestionnare.Current as Questionnare;
            //Dao.Questionnare.Delete(CurrentQuestionnare); <- 문진표 추가기능 완성 시 테스트 할 것
            ReloadGridView();
        }



        //gridview refresh 함수
        private void ReloadGridView()
        {
            bdsQuestionnare.DataSource = Dao.Questionnare.GetWithDepartmentAndCustomerName();
        }

        
    }
}
