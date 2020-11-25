
namespace DKClinic.EmployeeProgram
{
    partial class TestForm
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
            this.empLogin1 = new DKClinic.EmployeeProgram.EmployeeLoginControl();
            this.SuspendLayout();
            // 
            // empLogin1
            // 
            this.empLogin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.empLogin1.Location = new System.Drawing.Point(0, 0);
            this.empLogin1.Name = "empLogin1";
            this.empLogin1.Size = new System.Drawing.Size(1262, 773);
            this.empLogin1.TabIndex = 0;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 773);
            this.Controls.Add(this.empLogin1);
            this.Name = "TestForm";
            this.Text = "Testform";
            this.ResumeLayout(false);

        }

        #endregion

        private EmployeeLoginControl empLogin1;
    }
}