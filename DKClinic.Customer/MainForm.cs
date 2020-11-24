using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKClinic.Customer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (pnlMain.Controls.Count > 0)
                pnlMain.Controls.Clear();

            UserControl1 control1 = new UserControl1();
            control1.Dock = DockStyle.Fill;
            //control1.
        }
    }

    
}
