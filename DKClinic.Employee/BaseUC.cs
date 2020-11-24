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
    public abstract partial class BaseUC : UserControl
    {
        public BaseUC()
        {
            InitializeComponent();
        }

        public abstract string Title { get; set; }
    }
}
