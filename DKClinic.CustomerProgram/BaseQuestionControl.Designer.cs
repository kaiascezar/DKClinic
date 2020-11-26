
namespace DKClinic.CustomerProgram
{
    public abstract partial class BaseQuestionControl
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
            this.lblQuestion = new System.Windows.Forms.Label();
            this.pnlAnswer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.Font = new System.Drawing.Font("굴림", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblQuestion.Location = new System.Drawing.Point(0, 0);
            this.lblQuestion.Margin = new System.Windows.Forms.Padding(0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(800, 100);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlAnswer
            // 
            this.pnlAnswer.Location = new System.Drawing.Point(0, 100);
            this.pnlAnswer.Name = "pnlAnswer";
            this.pnlAnswer.Size = new System.Drawing.Size(800, 100);
            this.pnlAnswer.TabIndex = 1;
            // 
            // BaseQuestion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pnlAnswer);
            this.Controls.Add(this.lblQuestion);
            this.Name = "BaseQuestion";
            this.Size = new System.Drawing.Size(800, 200);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblQuestion;
        protected System.Windows.Forms.Panel pnlAnswer;
    }
}
