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
    public partial class EmployeeLoginControl : BaseUC
    {
        public EmployeeLoginControl()
        {
            InitializeComponent();
        }

        private void btnChangePw_Click(object sender, EventArgs e)
        {
            EmployeeChangePasswordForm empChangePw = new EmployeeChangePasswordForm();
            empChangePw.ShowDialog();
        }
    }
}
