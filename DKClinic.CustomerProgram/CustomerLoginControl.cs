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
    public partial class CustomerLoginControl : BaseUC
    {
        Data.Customer customer = new Data.Customer();
        public CustomerLoginControl()
        {
            InitializeComponent();
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            Data.Customer customer = Dao.Customer.Find(txbName.Text, txbBirthdate.Text);

            if (customer == null)
            {
                customer.Name = txbName.Text;
                customer.Birthdate = txbBirthdate.Text;
            }
            
            CustomerInputDetailControl ctmInputDetail1 = new CustomerInputDetailControl();

            if (customer.CustomerID != 0)
            {
                MessageBox.Show("방문기록이 있습니다.");
            }
            else
            {
                MessageBox.Show("환영합니다. 처음 방문하셨습니다.");
            }
            OnLoginToDetail(customer, ctmInputDetail1);
        }

        #region LoginToDetail event things for C# 3.0
        public event EventHandler<LoginToDetailEventArgs> LoginToDetail;

        protected virtual void OnLoginToDetail(LoginToDetailEventArgs e)
        {
            if (LoginToDetail != null)
                LoginToDetail(this, e);
        }

        private LoginToDetailEventArgs OnLoginToDetail(Data.Customer customer, CustomerInputDetailControl ctmInputDetail1)
        {
            LoginToDetailEventArgs args = new LoginToDetailEventArgs(customer, ctmInputDetail1);
            OnLoginToDetail(args);

            return args;
        }

        private LoginToDetailEventArgs OnLoginToDetailForOut()
        {
            LoginToDetailEventArgs args = new LoginToDetailEventArgs();
            OnLoginToDetail(args);

            return args;
        }

        public class LoginToDetailEventArgs : EventArgs
        {
            public Data.Customer Customer { get; set; }
            public CustomerInputDetailControl CtmInputDetail1 { get; set; }

            public LoginToDetailEventArgs()
            {
            }

            public LoginToDetailEventArgs(Data.Customer customer, CustomerInputDetailControl ctmInputDetail1)
            {
                Customer = customer;
                CtmInputDetail1 = ctmInputDetail1;
            }
        }
        #endregion
    }
}
