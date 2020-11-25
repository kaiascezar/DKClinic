using System;
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


        //취소버튼 이벤트
        #region btnCancelClicked event things for C# 3.0
        public event EventHandler<btnCancelClickedEventArgs> btnCancelClicked;

        protected virtual void OnbtnCancelClicked(btnCancelClickedEventArgs e)
        {
            if (btnCancelClicked != null)
                btnCancelClicked(this, e);
        }

        protected virtual btnCancelClickedEventArgs OnbtnCancelClicked(BaseUC baseUC)
        {
            btnCancelClickedEventArgs args = new btnCancelClickedEventArgs(baseUC);
            OnbtnCancelClicked(args);

            return args;
        }

        private btnCancelClickedEventArgs OnbtnCancelClickedForOut()
        {
            btnCancelClickedEventArgs args = new btnCancelClickedEventArgs();
            OnbtnCancelClicked(args);

            return args;
        }

        public class btnCancelClickedEventArgs : EventArgs
        {
            public BaseUC BaseUC { get; set; }

            public btnCancelClickedEventArgs()
            {
            }

            public btnCancelClickedEventArgs(BaseUC baseUC)
            {
                BaseUC = baseUC;
            }
        }
        #endregion
    }
}
