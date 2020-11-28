
namespace DKClinic.EmployeeProgram
{
    partial class EmployeeSelectFunctionControl
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
            this.btnManageQuestionnare = new System.Windows.Forms.Button();
            this.btnManageEmp = new System.Windows.Forms.Button();
            this.btnManageCtm = new System.Windows.Forms.Button();
            this.btnManageQuestion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManageQuestionnare
            // 
            this.btnManageQuestionnare.BackColor = System.Drawing.Color.Aqua;
            this.btnManageQuestionnare.Font = new System.Drawing.Font("Gulim", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManageQuestionnare.Location = new System.Drawing.Point(70, 64);
            this.btnManageQuestionnare.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManageQuestionnare.Name = "btnManageQuestionnare";
            this.btnManageQuestionnare.Size = new System.Drawing.Size(438, 160);
            this.btnManageQuestionnare.TabIndex = 0;
            this.btnManageQuestionnare.Tag = "1";
            this.btnManageQuestionnare.Text = "문진표 관리";
            this.btnManageQuestionnare.UseVisualStyleBackColor = false;
            this.btnManageQuestionnare.Click += new System.EventHandler(this.btnFunction_Click);
            // 
            // btnManageEmp
            // 
            this.btnManageEmp.BackColor = System.Drawing.Color.Yellow;
            this.btnManageEmp.Font = new System.Drawing.Font("Gulim", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManageEmp.Location = new System.Drawing.Point(600, 320);
            this.btnManageEmp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManageEmp.Name = "btnManageEmp";
            this.btnManageEmp.Size = new System.Drawing.Size(438, 160);
            this.btnManageEmp.TabIndex = 3;
            this.btnManageEmp.Tag = "4";
            this.btnManageEmp.Text = "직원 관리";
            this.btnManageEmp.UseVisualStyleBackColor = false;
            this.btnManageEmp.Click += new System.EventHandler(this.btnFunction_Click);
            // 
            // btnManageCtm
            // 
            this.btnManageCtm.BackColor = System.Drawing.Color.Lime;
            this.btnManageCtm.Font = new System.Drawing.Font("Gulim", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManageCtm.Location = new System.Drawing.Point(70, 320);
            this.btnManageCtm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManageCtm.Name = "btnManageCtm";
            this.btnManageCtm.Size = new System.Drawing.Size(438, 160);
            this.btnManageCtm.TabIndex = 2;
            this.btnManageCtm.Tag = "3";
            this.btnManageCtm.Text = "환자 관리";
            this.btnManageCtm.UseVisualStyleBackColor = false;
            this.btnManageCtm.Click += new System.EventHandler(this.btnFunction_Click);
            // 
            // btnManageQuestion
            // 
            this.btnManageQuestion.BackColor = System.Drawing.Color.Fuchsia;
            this.btnManageQuestion.Font = new System.Drawing.Font("Gulim", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManageQuestion.Location = new System.Drawing.Point(600, 64);
            this.btnManageQuestion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManageQuestion.Name = "btnManageQuestion";
            this.btnManageQuestion.Size = new System.Drawing.Size(438, 160);
            this.btnManageQuestion.TabIndex = 1;
            this.btnManageQuestion.Tag = "2";
            this.btnManageQuestion.Text = "문진표 질문 관리";
            this.btnManageQuestion.UseVisualStyleBackColor = false;
            this.btnManageQuestion.Click += new System.EventHandler(this.btnFunction_Click);
            // 
            // EmployeeSelectFunctionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnManageQuestion);
            this.Controls.Add(this.btnManageCtm);
            this.Controls.Add(this.btnManageEmp);
            this.Controls.Add(this.btnManageQuestionnare);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EmployeeSelectFunctionControl";
            this.Size = new System.Drawing.Size(1104, 538);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageQuestionnare;
        private System.Windows.Forms.Button btnManageEmp;
        private System.Windows.Forms.Button btnManageCtm;
        private System.Windows.Forms.Button btnManageQuestion;
    }
}
