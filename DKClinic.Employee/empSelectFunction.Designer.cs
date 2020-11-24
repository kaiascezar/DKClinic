
namespace DKClinic.Employee
{
    partial class empSelectFunction
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
            this.btnManageQuestionare = new System.Windows.Forms.Button();
            this.btnManageEmp = new System.Windows.Forms.Button();
            this.btnManageCtm = new System.Windows.Forms.Button();
            this.btnManageQuestion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManageQuestionare
            // 
            this.btnManageQuestionare.BackColor = System.Drawing.Color.Aqua;
            this.btnManageQuestionare.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManageQuestionare.Location = new System.Drawing.Point(80, 80);
            this.btnManageQuestionare.Name = "btnManageQuestionare";
            this.btnManageQuestionare.Size = new System.Drawing.Size(500, 200);
            this.btnManageQuestionare.TabIndex = 0;
            this.btnManageQuestionare.Text = "문진표 관리";
            this.btnManageQuestionare.UseVisualStyleBackColor = false;
            // 
            // btnManageEmp
            // 
            this.btnManageEmp.BackColor = System.Drawing.Color.Yellow;
            this.btnManageEmp.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManageEmp.Location = new System.Drawing.Point(686, 400);
            this.btnManageEmp.Name = "btnManageEmp";
            this.btnManageEmp.Size = new System.Drawing.Size(500, 200);
            this.btnManageEmp.TabIndex = 1;
            this.btnManageEmp.Text = "직원 관리";
            this.btnManageEmp.UseVisualStyleBackColor = false;
            // 
            // btnManageCtm
            // 
            this.btnManageCtm.BackColor = System.Drawing.Color.Lime;
            this.btnManageCtm.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManageCtm.Location = new System.Drawing.Point(80, 400);
            this.btnManageCtm.Name = "btnManageCtm";
            this.btnManageCtm.Size = new System.Drawing.Size(500, 200);
            this.btnManageCtm.TabIndex = 2;
            this.btnManageCtm.Text = "환자 관리";
            this.btnManageCtm.UseVisualStyleBackColor = false;
            // 
            // btnManageQuestion
            // 
            this.btnManageQuestion.BackColor = System.Drawing.Color.Fuchsia;
            this.btnManageQuestion.Font = new System.Drawing.Font("굴림", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManageQuestion.Location = new System.Drawing.Point(686, 80);
            this.btnManageQuestion.Name = "btnManageQuestion";
            this.btnManageQuestion.Size = new System.Drawing.Size(500, 200);
            this.btnManageQuestion.TabIndex = 3;
            this.btnManageQuestion.Text = "문진표 질문 관리";
            this.btnManageQuestion.UseVisualStyleBackColor = false;
            // 
            // empSelectFunction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnManageQuestion);
            this.Controls.Add(this.btnManageCtm);
            this.Controls.Add(this.btnManageEmp);
            this.Controls.Add(this.btnManageQuestionare);
            this.Name = "empSelectFunction";
            this.Size = new System.Drawing.Size(1262, 673);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageQuestionare;
        private System.Windows.Forms.Button btnManageEmp;
        private System.Windows.Forms.Button btnManageCtm;
        private System.Windows.Forms.Button btnManageQuestion;
    }
}
