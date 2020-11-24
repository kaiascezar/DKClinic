using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKClinic.Data
{
    public partial class BaseUC : UserControl
    {
        public BaseUC()
        {
            InitializeComponent();
        }

        public string Title { get; set; }
    }
}
