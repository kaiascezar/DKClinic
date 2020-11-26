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
    public partial class CustomerDepartmentChoiceControl : BaseUC
    {
        public CustomerDepartmentChoiceControl()
        {
            InitializeComponent();
        }

        CustomerQuestionnareControl custQuestionnare = new CustomerQuestionnareControl();

        private void btnMG_Click(object sender, EventArgs e)
        {
            Department department = Dao.Department.GetByPK(1);
            OnDepartmentToQuestionnare(department.DepartmentID, custQuestionnare);
        }
        private void btnNU_Click(object sender, EventArgs e)
        {
            Department department = Dao.Department.GetByPK(2);
            OnDepartmentToQuestionnare(department.DepartmentID, custQuestionnare);
        }
        private void btnDR_Click(object sender, EventArgs e)
        {
            Department department = Dao.Department.GetByPK(3);
            OnDepartmentToQuestionnare(department.DepartmentID, custQuestionnare);
        }
        private void btnFM_Click(object sender, EventArgs e)
        {
            Department department = Dao.Department.GetByPK(4);
            OnDepartmentToQuestionnare(department.DepartmentID, custQuestionnare);
        }

        #region DepartmentToQuestionnare event things for C# 3.0
        public event EventHandler<DepartmentToQuestionnareEventArgs> DepartmentToQuestionnare;

        protected virtual void OnDepartmentToQuestionnare(DepartmentToQuestionnareEventArgs e)
        {
            if (DepartmentToQuestionnare != null)
                DepartmentToQuestionnare(this, e);
        }

        private DepartmentToQuestionnareEventArgs OnDepartmentToQuestionnare(int departmentID, CustomerQuestionnareControl custQuestionnare)
        {
            DepartmentToQuestionnareEventArgs args = new DepartmentToQuestionnareEventArgs(departmentID, custQuestionnare);
            OnDepartmentToQuestionnare(args);

            return args;
        }

        private DepartmentToQuestionnareEventArgs OnDepartmentToQuestionnareForOut()
        {
            DepartmentToQuestionnareEventArgs args = new DepartmentToQuestionnareEventArgs();
            OnDepartmentToQuestionnare(args);

            return args;
        }

        public class DepartmentToQuestionnareEventArgs : EventArgs
        {
            public int DepartmentID { get; set; }
            public CustomerQuestionnareControl CustQuestionnare { get; set; }

            public DepartmentToQuestionnareEventArgs()
            {
            }

            public DepartmentToQuestionnareEventArgs(int departmentID, CustomerQuestionnareControl custQuestionnare)
            {
                DepartmentID = departmentID;
                CustQuestionnare = custQuestionnare;
            }
        }
        #endregion
    }

}
