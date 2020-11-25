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
    public partial class ctmLogin : BaseUC
    {
        Data.Customer Customer = new Data.Customer();
        public ctmLogin()
        {
            InitializeComponent();
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            Customer.Name = txbName.Text;
            //Customer.Birthdate = txbBirthdate.Text;
            ctmInputDetail ctmInputDetail1 = new ctmInputDetail();

            if (Customer.Name == "abc")
            {
                MessageBox.Show("방문기록이 있습니다.");
                ctmInputDetail1.Show();
            }
            else
            {
                MessageBox.Show("환영합니다. 처음 방문하셨습니다.");
                ctmInputDetail1.Show();
            }

            //OnNewCustomer(Customer, ctmInputDetail1);
            
        }

        #region NewCustomer event things for C# 3.0
        public event EventHandler<NewCustomerEventArgs> NewCustomer;

        protected virtual void OnNewCustomer(NewCustomerEventArgs e)
        {
            if (NewCustomer != null)
                NewCustomer(this, e);
        }

        private NewCustomerEventArgs OnNewCustomer(Data.Customer customer, ctmInputDetail ctmInputDetail1)
        {
            NewCustomerEventArgs args = new NewCustomerEventArgs(customer, ctmInputDetail1);
            OnNewCustomer(args);

            return args;
        }

        private NewCustomerEventArgs OnNewCustomerForOut()
        {
            NewCustomerEventArgs args = new NewCustomerEventArgs();
            OnNewCustomer(args);

            return args;
        }

        public class NewCustomerEventArgs : EventArgs
        {
            public Data.Customer Customer { get; set; }
            public ctmInputDetail CtmInputDetail1 { get; set; }

            public NewCustomerEventArgs()
            {
            }

            public NewCustomerEventArgs(Data.Customer customer, ctmInputDetail ctmInputDetail1)
            {
                Customer = customer;
                CtmInputDetail1 = ctmInputDetail1;
            }
        }
        #endregion
    }
}
