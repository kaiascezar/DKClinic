using DKClinic.Data;
using System;

namespace DKClinic.CustomerProgram
{
    public partial class CustomerDepartmentChoiceControl : BaseUC
    {
        public CustomerDepartmentChoiceControl()
        {
            InitializeComponent();
            Title = "진료과 선택";
        }

        /// <summary>
        /// 내과 - MG(Medicus Gratus)
        /// </summary>
        private void btnMG_Click(object sender, EventArgs e)
        {
            Department department = Dao.Department.GetByPK(1);
            CustomerQuestionnareControl custQuestionnare = new CustomerQuestionnareControl(department.DepartmentID);
            OnDepartmentToQuestionnare(department.DepartmentID, custQuestionnare);
        }
        /// <summary>
        /// 신경과 - NU(NeUrology)
        /// </summary>
        private void btnNU_Click(object sender, EventArgs e)
        {
            Department department = Dao.Department.GetByPK(2);
            CustomerQuestionnareControl custQuestionnare = new CustomerQuestionnareControl(department.DepartmentID);
            OnDepartmentToQuestionnare(department.DepartmentID, custQuestionnare);
        }
        /// <summary>
        /// 피부과 - DR(DeRmatology)
        /// </summary>
        private void btnDR_Click(object sender, EventArgs e)
        {
            Department department = Dao.Department.GetByPK(3);
            CustomerQuestionnareControl custQuestionnare = new CustomerQuestionnareControl(department.DepartmentID);
            OnDepartmentToQuestionnare(department.DepartmentID, custQuestionnare);
        }
        /// <summary>
        /// 가정의학과 - FM(Family Medicine)
        /// </summary>
        private void btnFM_Click(object sender, EventArgs e)
        {
            Department department = Dao.Department.GetByPK(4);
            CustomerQuestionnareControl custQuestionnare = new CustomerQuestionnareControl(department.DepartmentID);
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
