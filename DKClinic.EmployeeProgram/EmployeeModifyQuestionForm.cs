using DKClinic.Data;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DKClinic.EmployeeProgram
{
    public partial class EmployeeModifyQuestionForm : Form
    {
        public Question Question { get; set; }
        public int QuestionCount { get; set; }
        public bool IsChaneged { get; set; }

        public EmployeeModifyQuestionForm()
        {
            InitializeComponent();
        }

        public EmployeeModifyQuestionForm(int questionCount) : this()
        {
            // Insert
            Question = new Question();
            QuestionCount = questionCount;
            IsChaneged = false;
        }

        public EmployeeModifyQuestionForm(Question qusetion, int questionCount) : this(questionCount)
        {
            // Update
            Question = qusetion;

            txbIndexNum.Text = Question.Index.ToString();
            txbItem.Text = Question.Item;
            string[] choices = (Question.Choices).Split(',');
            foreach(var choice in choices)
                txbChoices.Text += $"{choice}\n";
            cmbSelectType.SelectedIndex = Question.Type - 1;
        }

        private void txbIndexNum_TextChanged(object sender, EventArgs e)
        {
            if(int.Parse(txbIndexNum.Text) > QuestionCount && Question.QuestionID != 0)
            {
                // 수정의 경우, 문제 개수를 넘어갈 수 없다
                MessageBox.Show("문제의 범위가 초과되었습니다");
                txbIndexNum.Text = Question.QuestionID.ToString();
            }
            else if(int.Parse(txbIndexNum.Text) > QuestionCount + 1 && Question.QuestionID == 0)
            {
                // 추가의 경우, 문제 개수 +1 을 넘어갈 수 없다
                MessageBox.Show("문제의 범위가 초과되었습니다");
                txbIndexNum.Text = (QuestionCount + 1).ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 유효성 검사
            if(txbItem.Text == "" ||
                cmbSelectType.SelectedIndex == -1 ||
                (txbChoices.Text == "" && txbChoices.Enabled == true))
            {
                MessageBox.Show("모두 입력해 주세요");
                return;
            }

            List<string> choices = new List<string>();
            if (txbChoices.Enabled)
            {
                foreach (string str in txbChoices.Lines)
                    if (str != "")
                        choices.Add(str);

                if (choices.Count > 6 || choices.Count < 3)
                {
                    MessageBox.Show("문항의 개수는 3개 이상 6개 이하만 가능합니다");
                    return;
                }
            }

            // 데이터 버퍼에 저장
            Question.Index = int.Parse(txbIndexNum.Text);
            Question.Item = txbItem.Text;
            Question.Type = cmbSelectType.SelectedIndex + 1;
            if (txbChoices.Enabled)
            {
                Question.ChoiceCount = choices.Count;
                Question.Choices = "";
                for (int i = 0; i < choices.Count; i++)
                {
                    if (i == 0)
                        Question.Choices += choices[i];
                    else
                        Question.Choices += "," + choices[i];
                }
            }
            else
            {
                Question.ChoiceCount = null;
                Question.Choices = null;
            }

            IsChaneged = true;

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbSelectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectType.SelectedIndex == 0)
                txbChoices.Enabled = false;
            else
                txbChoices.Enabled = true;
        }
    }
}
