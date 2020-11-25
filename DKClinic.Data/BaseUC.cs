using System.Windows.Forms;

namespace DKClinic.Data
{
    public partial class BaseUC : UserControl
    {
        public BaseUC()
        {
            InitializeComponent();
            Title = string.Empty;
        }

        public string Title { get; set; }
    }
}
