using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKClinic.Employee
{
    public partial class empLogin : UserControl
    {
        public empLogin()
        {
            InitializeComponent();
        }

        private void btnChangePw_Click(object sender, EventArgs e)
        {
            empChangePw empChangePw = new empChangePw();
            empChangePw.ShowDialog();
        }
    }
}
