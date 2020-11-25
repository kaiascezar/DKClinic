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
        public CustomerLoginControl()
        {
            InitializeComponent();
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            Customer customer = Dao.Customer.Find(txbName.Text, txbBirthdate.Text);

            if (customer == null)
            {
                customer = new Customer();
                customer.Name = txbName.Text;
                customer.Birthdate = txbBirthdate.Text;
            }
            
            CustomerInputDetailControl ctmInputDetail = new CustomerInputDetailControl(/*customer*/);

            if (customer.CustomerID != 0)
            {
                MessageBox.Show("방문기록이 있습니다.");
            }
            else
            {
                MessageBox.Show("환영합니다. 처음 방문하셨습니다.");
            }
            OnLoginToDetail(customer, ctmInputDetail);
        }
        
        #region LoginToDetail event things for C# 3.0
        public event EventHandler<LoginToDetailEventArgs> LoginToDetail;

        protected virtual void OnLoginToDetail(LoginToDetailEventArgs e)
        {
            if (LoginToDetail != null)
                LoginToDetail(this, e);
        }

        private LoginToDetailEventArgs OnLoginToDetail(Customer customer, CustomerInputDetailControl ctmInputDetail)
        {
            LoginToDetailEventArgs args = new LoginToDetailEventArgs(customer, ctmInputDetail);
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
            public Customer Customer { get; set; }
            public CustomerInputDetailControl CtmInputDetail { get; set; }

            public LoginToDetailEventArgs()
            {
            }

            public LoginToDetailEventArgs(Customer customer, CustomerInputDetailControl ctmInputDetail)
            {
                Customer = customer;
                CtmInputDetail = ctmInputDetail;
            }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txbName.Clear();
            txbBirthdate.Clear();
        }
    }
}
