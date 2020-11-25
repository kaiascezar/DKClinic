
namespace DKClinic.EmployeeProgram
{
    partial class EmployeeManageQuestionareControl
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
            this.dgvQuestionareList = new System.Windows.Forms.DataGridView();
            this.btnOpenResponse = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionareList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvQuestionareList
            // 
            this.dgvQuestionareList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuestionareList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestionareList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvQuestionareList.Location = new System.Drawing.Point(100, 10);
            this.dgvQuestionareList.Name = "dgvQuestionareList";
            this.dgvQuestionareList.RowHeadersWidth = 51;
            this.dgvQuestionareList.RowTemplate.Height = 27;
            this.dgvQuestionareList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvQuestionareList.Size = new System.Drawing.Size(1062, 500);
            this.dgvQuestionareList.TabIndex = 0;
            // 
            // btnOpenResponse
            // 
            this.btnOpenResponse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenResponse.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOpenResponse.Location = new System.Drawing.Point(100, 550);
            this.btnOpenResponse.Name = "btnOpenResponse";
            this.btnOpenResponse.Size = new System.Drawing.Size(365, 95);
            this.btnOpenResponse.TabIndex = 1;
            this.btnOpenResponse.Text = "열람 / 진단서 작성";
            this.btnOpenResponse.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDelete.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Location = new System.Drawing.Point(533, 550);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(280, 95);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnGoBack
            // 
            this.btnGoBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoBack.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGoBack.Location = new System.Drawing.Point(882, 550);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(280, 95);
            this.btnGoBack.TabIndex = 3;
            this.btnGoBack.Text = "뒤로가기";
            this.btnGoBack.UseVisualStyleBackColor = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "No.";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 162;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "환자 이름";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 450;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "작성 날짜";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 450;
            // 
            // empManageQuestionare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnOpenResponse);
            this.Controls.Add(this.dgvQuestionareList);
            this.Name = "empManageQuestionare";
            this.Size = new System.Drawing.Size(1262, 673);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionareList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvQuestionareList;
        private System.Windows.Forms.Button btnOpenResponse;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}
