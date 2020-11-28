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
        public Employee CurrentEmployeeInHere { get; set; }

        public EmployeeManageControl()
        {
            InitializeComponent();
            Title = "직원 정보 관리";

            employeeBindingSource.DataSource = Dao.Employee.GetWithDepartmentAndPositionName();
        }

        public EmployeeManageControl(Employee employee) : this()
        {
            CurrentEmployeeInHere = employee;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txbName.Text != "")
                employeeBindingSource.DataSource = Dao.Employee.GetWithDepartmentAndPositionNameByName(txbName.Text);
            else
                employeeBindingSource.DataSource = Dao.Employee.GetWithDepartmentAndPositionName();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //신규 폼 열기
            EmployeeUpdateInfoForm employeeUpdateInfoForm = new EmployeeUpdateInfoForm();
            employeeUpdateInfoForm.ShowDialog();
            
            employeeBindingSource.DataSource = Dao.Employee.GetWithDepartmentAndPositionName();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //포커스된 데이터 확인
            Employee employee = employeeBindingSource.Current as Employee;
            if (employee == null)
                return;

            //포커스된 데이터를 바탕으로 정보 전달
            EmployeeUpdateInfoForm employeeUpdateInfoForm = new EmployeeUpdateInfoForm(employee);
            employeeUpdateInfoForm.ShowDialog();
            
            employeeBindingSource.DataSource = Dao.Employee.GetWithDepartmentAndPositionName();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //포커스된 데이터 확인
            Employee employee = employeeBindingSource.Current as Employee;
            if (employee == null)
                return;
            //삭제 메세지 박스
            if (WinformUtility.AskSure("정말로 삭제하시겠습니까?"))
                Dao.Employee.Delete(employee);

            employeeBindingSource.DataSource = Dao.Employee.GetWithDepartmentAndPositionName();
        }
        private void btnGoBack_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(((MainForm)ParentForm).ConnectedEmployee.Name);

            EmployeeSelectFunctionControl employeeSelectFunctionControl = new EmployeeSelectFunctionControl(CurrentEmployeeInHere);
            OnbtnCancelClicked(employeeSelectFunctionControl);
        }

    }
}
