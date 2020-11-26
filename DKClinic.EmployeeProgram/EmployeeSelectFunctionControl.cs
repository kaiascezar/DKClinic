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
        public EmployeeSelectFunctionControl()
        {
            InitializeComponent();
        }

        
        
        
        

        private void btnManageQuestionare_Click(object sender, EventArgs e)
        {
            EmployeeManageQuestionareControl empmngQuestionnareCtrl = new EmployeeManageQuestionareControl();
        }

        private void btnManageQuestion_Click(object sender, EventArgs e)
        {
            EmployeeManageQuestionControl emplmngQuestionCtrl = new EmployeeManageQuestionControl();
        }

        private void btnManageCtm_Click(object sender, EventArgs e)
        {
            EmployeeManageCustomerControl emplmngCustomerCtrl = new EmployeeManageCustomerControl();
        }

        private void btnManageEmp_Click(object sender, EventArgs e)
        {
            EmployeeManageControl empmngCtrl = new EmployeeManageControl();
        }
    }
}
