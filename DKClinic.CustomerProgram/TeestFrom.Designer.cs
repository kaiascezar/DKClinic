
namespace DKClinic.CustomerProgram
{
    partial class TeestFrom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ctmInputDetail1 = new DKClinic.CustomerProgram.CustomerInputDetailControl();
            this.SuspendLayout();
            // 
            // ctmInputDetail1
            // 
            this.ctmInputDetail1.BackColor = System.Drawing.Color.Transparent;
            this.ctmInputDetail1.Location = new System.Drawing.Point(3, 0);
            this.ctmInputDetail1.Name = "ctmInputDetail1";
            this.ctmInputDetail1.Size = new System.Drawing.Size(1260, 670);
            this.ctmInputDetail1.TabIndex = 0;
            this.ctmInputDetail1.Title = "";
            // 
            // TeestFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.ctmInputDetail1);
            this.Name = "TeestFrom";
            this.Text = "TeestFrom";
            this.ResumeLayout(false);

        }

        #endregion

        private CustomerInputDetailControl ctmInputDetail1;
    }
}