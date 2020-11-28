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
        public EmployeeManageQuestionnareControl(Employee currentEmployee)
        {
            InitializeComponent();
            Title = "문진표 관리";
            currentEmployeeInHere = currentEmployee;
            ReloadGridViewWithDepartment();
            
        }

        

        public Questionnare currentQuestionnare { get; set; }
        private Employee currentEmployeeInHere { get; }

        //뒤로가기버튼
        private void btnGoBack_Click(object sender, EventArgs e)
        {
            EmployeeSelectFunctionControl employeeSelectFunctionControl = new EmployeeSelectFunctionControl(currentEmployeeInHere);
            
            OnbtnCancelClicked(employeeSelectFunctionControl);
        }


        //문진표 열람 & 진단서 작성
        private void btnOpenResponse_Click(object sender, EventArgs e)
        {
            currentQuestionnare = bdsQuestionnare.Current as Questionnare;
            if (currentQuestionnare == null) // 선택된 값이 없으면 return
            {
                return;
            }
            //문진표 열람 & 진단서 작성 폼 호출 및 gridview 내 선택된 값 전달용 변수
            EmployeeModifyQuestionnareForm employeeModifyQuestionnareForm = new EmployeeModifyQuestionnareForm(currentQuestionnare, currentEmployeeInHere);
            employeeModifyQuestionnareForm.ShowDialog();
        }

        //삭제버튼
        private void btnDelete_Click(object sender, EventArgs e)
        {
            currentQuestionnare = bdsQuestionnare.Current as Questionnare;
            if (currentQuestionnare == null) // 선택된 값이 없으면 return
            {
                return;
            }
            Dao.Questionnare.Delete(currentQuestionnare);
            ReloadGridViewWithDepartment();
        }

        //gridview refresh 함수
        private void ReloadGridViewWithDepartment()
        {
            bdsQuestionnare.DataSource = Dao.Questionnare.GetWithDepartmentAndCustomerName(currentEmployeeInHere);
        }

        
    }
}
