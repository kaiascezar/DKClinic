
namespace DKClinic.Customer
{
    partial class ctmDepChoice
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnMG = new System.Windows.Forms.Button();
            this.btnNU = new System.Windows.Forms.Button();
            this.btnFM = new System.Windows.Forms.Button();
            this.btnDR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMG
            // 
            this.btnMG.BackColor = System.Drawing.Color.Lime;
            this.btnMG.Font = new System.Drawing.Font("Gulim", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMG.Location = new System.Drawing.Point(60, 60);
            this.btnMG.Name = "btnMG";
            this.btnMG.Size = new System.Drawing.Size(500, 200);
            this.btnMG.TabIndex = 0;
            this.btnMG.Text = "내과";
            this.btnMG.UseVisualStyleBackColor = false;
            // 
            // btnNU
            // 
            this.btnNU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnNU.Font = new System.Drawing.Font("Gulim", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNU.Location = new System.Drawing.Point(670, 60);
            this.btnNU.Name = "btnNU";
            this.btnNU.Size = new System.Drawing.Size(500, 200);
            this.btnNU.TabIndex = 1;
            this.btnNU.Text = "신경과";
            this.btnNU.UseVisualStyleBackColor = false;
            // 
            // btnFM
            // 
            this.btnFM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnFM.Font = new System.Drawing.Font("Gulim", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFM.Location = new System.Drawing.Point(670, 380);
            this.btnFM.Name = "btnFM";
            this.btnFM.Size = new System.Drawing.Size(500, 200);
            this.btnFM.TabIndex = 3;
            this.btnFM.Text = "가정의학과";
            this.btnFM.UseVisualStyleBackColor = false;
            // 
            // btnDR
            // 
            this.btnDR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnDR.Font = new System.Drawing.Font("Gulim", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDR.Location = new System.Drawing.Point(60, 380);
            this.btnDR.Name = "btnDR";
            this.btnDR.Size = new System.Drawing.Size(500, 200);
            this.btnDR.TabIndex = 2;
            this.btnDR.Text = "피부과";
            this.btnDR.UseVisualStyleBackColor = false;
            // 
            // ctmDepChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnFM);
            this.Controls.Add(this.btnDR);
            this.Controls.Add(this.btnNU);
            this.Controls.Add(this.btnMG);
            this.Name = "ctmDepChoice";
            this.Size = new System.Drawing.Size(1262, 673);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMG;
        private System.Windows.Forms.Button btnNU;
        private System.Windows.Forms.Button btnFM;
        private System.Windows.Forms.Button btnDR;
    }
}
