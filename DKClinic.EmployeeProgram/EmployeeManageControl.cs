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
    public partial class EmployeeManageControl : BaseUC
    {
        public EmployeeManageControl()
        {
            InitializeComponent();
            Title = "직원 정보 관리";

            employeeBindingSource.DataSource = Dao.Employee.GetWithDepartmentAndPositionName();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(((MainForm)ParentForm).ConnectedEmployee.Name);

            EmployeeSelectFunctionControl emplselfunControl = new EmployeeSelectFunctionControl();
            OnbtnCancelClicked(emplselfunControl);
        }
    }
}
