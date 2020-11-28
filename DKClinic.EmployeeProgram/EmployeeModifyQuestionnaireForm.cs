using DKClinic.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DKClinic.EmployeeProgram
{
    public partial class EmployeeModifyQuestionnareForm : Form
    {
        public EmployeeModifyQuestionnareForm(Questionnare questionnaire, Employee employee)
        {
            InitializeComponent();
            currentEmployeeInHere = employee;

            //판넬에 문진표 작성 내용 출력, 문진표 출력 내용은 CustomerQustionnareControl.cs 참고            
            currentQuestionnaireInHere = questionnaire;

            txbBoard.Text = 
                $"환자이름: {currentQuestionnaireInHere.CustomerName}\n\n" +
                $"문진표 내용:\n\n{printQuestionnaires(currentQuestionnaireInHere)}"; // 환자 이름 및 문진표 내용 타이틀 출력
     
            //진단내용 작성기능 사용 권한 부여
            if (currentEmployeeInHere.PositionID == 3)// DocrotID == Employee.PositionID 간호사는 3, 간호사는 진단내용 작성 불가
            {
                txbDiagnosis.Enabled = false;
            }
            else // 관리자(DoctorID = 1) 의사(DoctorID = 2) 는 작성가능
                txbDiagnosis.Enabled = true;


            //기존 작성된 진단 내용이 있을 시, 진단내용 출력 
            if (questionnaire.Diagnosis != null)
            {
                txbDiagnosis.Text = questionnaire.Diagnosis;
            }
        }
        private Employee currentEmployeeInHere { get; }
        private Questionnare currentQuestionnaireInHere { get; set; }
        public Questionnare questionnairesForQuery { get; set; }

        //문제 출력 함수
        private string printQuestionnaires(Questionnare currentQuestionnare)
        {
            questionnairesForQuery = currentQuestionnare;
            string unionQuestions = "";
            
            using (var context = DKClinicEntities.Create())
            {
                var query = from x in context.Responses
                            where x.QuestionnareID == questionnairesForQuery.QuestionnareID
                            orderby x.Question.Index
                            select new { questionIndex = x.Question.Index, 
                                         questionItem = x.Question.Item, 
                                         questionChoices = x.Question.Choices, 
                                         questionType = x.Question.Type, 
                                         questionResponse = x };

                var list = query.ToList();

                foreach (var item in list)
                {
                    unionQuestions += $" {item.questionIndex}. {item.questionItem}\n";

                    if (item.questionType != 1)
                    {
                        string[] choices = item.questionChoices.Split(',');
                        for (int i = 0; i < choices.Length; i++)
                            unionQuestions += $" {i + 1}) {choices[i]}\n";
                    }
                    unionQuestions += "\n";

                    unionQuestions += $" 답안 => {item.questionResponse.Answer}\n\n";
                }    

                return unionQuestions;
            }
        }

        //취소버튼
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        //저장버튼
        private void btnSave_Click(object sender, EventArgs e)
        {
            currentQuestionnaireInHere.Diagnosis = txbDiagnosis.Text;

            if (WinformUtility.AskSure("저장하시겠습니까?"))
            {
                if(txbDiagnosis == null)
                {
                    Dao.Questionnare.Insert(currentQuestionnaireInHere);
                    Close();
                }
                else
                {
                    Dao.Questionnare.Update(currentQuestionnaireInHere);
                    Close();
                }
                //using (var context = DKClinicEntities.Create())
                //{
                //    var query = from x in context.Questionnares
                //                where x.QuestionnareID == questionnairesForQuery.QuestionnareID
                //                select new { diagnosis = x.Diagnosis}
                //    var list = query.ToList();
                //    foreach (var item in list)
                //    {
                //        item.diagnosis = txbDiagnosis.Text;
                //    }

                //}
            }
            else
                return;
        }
    }
}
