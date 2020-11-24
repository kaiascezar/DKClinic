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
    public partial class ctmInputDetail : UserControl
    {
        public ctmInputDetail()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string name, birthdate, cellphone;
            int gender;

            name = tbxName.Text;
            birthdate = tbxBairthdate.Text;
            cellphone = tbxCellphone.Text;

            if (rbtMale.Checked == true) //male : 1  female : 2
                gender = 1;
            else
                gender = 2;
            MessageBox.Show($"{name}\n{birthdate}\n{gender}\n{cellphone}");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Canceled");
        }
    }
}
