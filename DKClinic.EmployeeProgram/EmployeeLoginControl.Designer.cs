﻿
namespace DKClinic.EmployeeProgram
{
    partial class EmployeeLoginControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChangePw = new System.Windows.Forms.Button();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Gulim", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(354, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "이름";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbName
            // 
            this.txbName.Font = new System.Drawing.Font("Gulim", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txbName.Location = new System.Drawing.Point(473, 107);
            this.txbName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(307, 44);
            this.txbName.TabIndex = 1;
            this.txbName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbName_KeyPress);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Gulim", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.Location = new System.Drawing.Point(350, 392);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(158, 76);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "확인";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Gulim", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(604, 392);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(176, 76);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "입력취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Gulim", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(354, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "PW";
            // 
            // btnChangePw
            // 
            this.btnChangePw.Font = new System.Drawing.Font("Gulim", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChangePw.Location = new System.Drawing.Point(350, 331);
            this.btnChangePw.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnChangePw.Name = "btnChangePw";
            this.btnChangePw.Size = new System.Drawing.Size(430, 43);
            this.btnChangePw.TabIndex = 4;
            this.btnChangePw.Text = "비밀번호 변경";
            this.btnChangePw.UseVisualStyleBackColor = true;
            this.btnChangePw.Click += new System.EventHandler(this.btnChangePw_Click);
            // 
            // txbPassword
            // 
            this.txbPassword.Font = new System.Drawing.Font("Gulim", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txbPassword.Location = new System.Drawing.Point(473, 206);
            this.txbPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.Size = new System.Drawing.Size(307, 44);
            this.txbPassword.TabIndex = 3;
            this.txbPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbPassword_KeyPress);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Gulim", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(350, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(430, 43);
            this.label3.TabIndex = 7;
            this.label3.Text = "직원 로그인";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmployeeLoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.btnChangePw);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EmployeeLoginControl";
            this.Size = new System.Drawing.Size(1104, 538);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChangePw;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label label3;
    }
}
