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
    public partial class EmployeeSelectFunctionControl : BaseUC
    {
        private Employee currentEmployeeInHere { get; }

        public EmployeeSelectFunctionControl()
        {
            InitializeComponent();
            Title = "작업 선택";
        }

        public EmployeeSelectFunctionControl(Employee employee) : this()
        {
            currentEmployeeInHere = employee;

            if (employee.PositionID == 1) // 관리자 : all
            {
                btnManageQuestionnare.Enabled = true;
                btnManageQuestion.Enabled = true;
                btnManageCtm.Enabled = true;
                btnManageEmp.Enabled = true;
            }
            else if (employee.PositionID == 2) // 의사 : 문진표, 질문, 환자 
            {
                btnManageQuestionnare.Enabled = true;
                btnManageQuestion.Enabled = true;
                btnManageCtm.Enabled = true;
                btnManageEmp.Enabled = false;
                btnManageEmp.BackColor = Color.Gray;
            }
            else if (employee.PositionID == 3) // 간호사 : 문진표(진단X), 환자
            {
                btnManageQuestionnare.Enabled = true;
                btnManageQuestion.Enabled = false;
                btnManageQuestion.BackColor = Color.Gray;
                btnManageCtm.Enabled = true;
                btnManageEmp.Enabled = false;
                btnManageEmp.BackColor = Color.Gray;
            }
        }

        private void btnFunction_Click(object sender, EventArgs e)
        {
            BaseUC baseUC = null;
            

            string buttonName = ((Button)sender).Name;
            if (buttonName == "btnManageQuestionnare")
                baseUC = new EmployeeManageQuestionnareControl(currentEmployeeInHere);
            else if (buttonName == "btnManageQuestion")
                baseUC = new EmployeeManageQuestionControl(currentEmployeeInHere);
            else if (buttonName == "btnManageCtm")
                baseUC = new EmployeeManageCustomerControl(currentEmployeeInHere);
            else if (buttonName == "btnManageEmp")
                baseUC = new EmployeeManageControl(currentEmployeeInHere);

            OnSelectToFunction(baseUC);
        }

        #region SelectToFunction event things for C# 3.0
        public event EventHandler<SelectToFunctionEventArgs> SelectToFunction;

        protected virtual void OnSelectToFunction(SelectToFunctionEventArgs e)
        {
            if (SelectToFunction != null)
                SelectToFunction(this, e);
        }

        private SelectToFunctionEventArgs OnSelectToFunction(BaseUC baseUC)
        {
            SelectToFunctionEventArgs args = new SelectToFunctionEventArgs(baseUC);
            OnSelectToFunction(args);

            return args;
        }

        private SelectToFunctionEventArgs OnSelectToFunctionForOut()
        {
            SelectToFunctionEventArgs args = new SelectToFunctionEventArgs();
            OnSelectToFunction(args);

            return args;
        }

        public class SelectToFunctionEventArgs : EventArgs
        {
            public BaseUC BaseUC { get; set; }

            public SelectToFunctionEventArgs()
            {
            }

            public SelectToFunctionEventArgs(BaseUC baseUC)
            {
                BaseUC = baseUC;
            }
        }
        #endregion
    }
}
