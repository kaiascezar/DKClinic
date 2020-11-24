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

namespace DKClinic.Customer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            MainControl = pnlMain.Controls;

            BaseUC control = new UserControl1();
            CallUserControl(control);

            //pnlTop.Enabled = false;
            //pnlBottom.Enabled = false;
        }

        public Control.ControlCollection MainControl { get; set; }

        public void CallUserControl(BaseUC control)
        {
            if (MainControl.Count > 0)
                MainControl.Clear();

            control.Dock = DockStyle.Fill;
            MainControl.Add(control);
            lblTitle.Text = control.Title;
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            if (MainControl.Count > 0)
                MainControl.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }
    }
}
