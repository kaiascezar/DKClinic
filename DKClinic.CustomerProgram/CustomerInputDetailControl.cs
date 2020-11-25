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
    public partial class CustomerInputDetailControl : BaseUC
    {
        public CustomerInputDetailControl()
        {
            InitializeComponent();
        }

        Data.Customer ctm = new Data.Customer(); // create customer obj


        protected bool checkCustomerID(Data.Customer ctm)
        {
            int ctmid = ctm.CustomerID;

            if (ctmid == 0)
                return false;
            else
                return true;           
        }
        

        private void btnOK_Click(object sender, EventArgs e)
        {
            
            
            //string name, birthdate, cellphone;
            //int gender;

            //CustomerInfo.name = txbName.Text;
            //birthdate = txbBirthdate.Text;
            //cellphone = txbCellphone.Text;

            //if (rbtMale.Checked == true) //male : 1  female : 2
            //    gender = 1;
            //else
            //    gender = 2;
            //MessageBox.Show($"{name}\n{birthdate}\n{gender}\n{cellphone}");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Canceled");
        }


        //#region ctmDetail event things for C# 3.0
        //    public event EventHandler<ctmDetailEventArgs> ctmDetail;

        //    protected virtual void OnctmDetail(ctmDetailEventArgs e)
        //    {
        //        if (ctmDetail != null)
        //            ctmDetail(this, e);
        //    }

        //    private ctmDetailEventArgs OnctmDetail(ref customerClass  , ref ctmDepChoice )
        //    {
        //        ctmDetailEventArgs args = new ctmDetailEventArgs(customerClass, ctmDepChoice);
        //        OnctmDetail(args);

        //        return args;
        //    }

        //    private ctmDetailEventArgs OnctmDetailForOut()
        //    {
        //        ctmDetailEventArgs args = new ctmDetailEventArgs();
        //        OnctmDetail(args);

        //        return args;
        //    }

        //    public class ctmDetailEventArgs : EventArgs
        //    {
        //        public ref CustomerClass { get; set;}
        //        public ref CtmDepChoice { get; set;}

        //        public ctmDetailEventArgs()
        //        {
        //        }

        //        public ctmDetailEventArgs(ref customerClass  , ref ctmDepChoice )
        //        {
        //            CustomerClass = customerClass;
        //            CtmDepChoice = ctmDepChoice;
        //        }
        //    }
        //#endregion
    }
}
