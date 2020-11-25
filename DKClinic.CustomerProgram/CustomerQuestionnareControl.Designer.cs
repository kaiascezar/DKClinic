
namespace DKClinic.CustomerProgram
{
    partial class CustomerQuestionnareControl
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
            this.pnlBoard = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlBoard
            // 
            this.pnlBoard.AutoScroll = true;
            this.pnlBoard.AutoScrollMinSize = new System.Drawing.Size(0, 1);
            this.pnlBoard.BackColor = System.Drawing.Color.Silver;
            this.pnlBoard.Location = new System.Drawing.Point(100, 10);
            this.pnlBoard.Name = "pnlBoard";
            this.pnlBoard.Size = new System.Drawing.Size(1062, 653);
            this.pnlBoard.TabIndex = 0;
            // 
            // ctmQuestionnare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlBoard);
            this.Name = "ctmQuestionnare";
            this.Size = new System.Drawing.Size(1262, 673);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBoard;
    }
}
