using DKClinic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DKClinic.EmployeeProgram
{
    public partial class EmployeeManageQuestionControl : BaseUC
    {
        public List<Question> BeforeQuestions { get; set; }
        public List<Question> AfterQuestions { get; set; }
        public Department Department { get; set; }
        public Employee CurrentEmployeeInHere { get; set; }

        public EmployeeManageQuestionControl()
        {
            InitializeComponent();
            Title = "문진표 질문 관리";
        }

        public EmployeeManageQuestionControl(Employee employee) : this()
        {
            CurrentEmployeeInHere = employee;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode)
                return;

            Department = Dao.Department.GetByPK(CurrentEmployeeInHere.DepartmentID);

            BeforeQuestions = Dao.Question.GetNewestVersionByDepartmentID(CurrentEmployeeInHere.DepartmentID);

            AfterQuestions = new List<Question>(BeforeQuestions);

            ReloadGridView();
        }

        private void ReloadGridView()
        {
            bdsQuestion.DataSource = Dao.Question.SelectionNewestVersionByLocalDepartment(
                Dao.Question.AddDepartmentNameAndTypeName(AfterQuestions), Department);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmployeeModifyQuestionForm addedQuestion = new EmployeeModifyQuestionForm((int)Department.Count);
            addedQuestion.ShowDialog();

            // Insert
            // 맨 뒤에 추가할 경우
            // Version갱신 후 Add + Department테이블 Count값+1
            // 중간에 추가할 경우 추가로
            // 바뀌는(밀리는) 문제들에 대해 변화되는 Index변화 + Version갱신 후 Add

            if (addedQuestion.IsChaneged)
            {
                // department 추가
                addedQuestion.Question.DepartmentID = Department.DepartmentID;

                // version 추가
                addedQuestion.Question.Version =
                    Dao.Question.GetNewestVersionNumber(AfterQuestions, addedQuestion.Question.DepartmentID,
                    addedQuestion.Question.Index) + 1;

                if (addedQuestion.Question.Index != Department.Count)
                {
                    List<Question> questions = new List<Question>();

                    for(int i = addedQuestion.Question.Index;
                        i <= Department.Count;i++ )
                    {
                        // 나머지 문제들을 깊은 복사하여 index와 version을 바꾸고 추가
                        var data = AfterQuestions.FindAll(x => x.Index == i)
                                .OrderByDescending(x => x.Version)
                                .FirstOrDefault();
                        Question question = (Question)data.Clone();
                        question.Index++;
                        question.Version = Dao.Question.GetNewestVersionNumber(AfterQuestions, question.DepartmentID, question.Index) + 1;
                        questions.Add(question);
                    }

                    foreach (Question item in questions)
                        AfterQuestions.Add(item);
                }

                AfterQuestions.Add(addedQuestion.Question);

                Department.Count++;
            }

            ReloadGridView();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int beforeQuestionIndex = ((Question)bdsQuestion.Current).Index;
            EmployeeModifyQuestionForm modifyQuestion = new EmployeeModifyQuestionForm((Question)bdsQuestion.Current, (int)Department.Count);
            modifyQuestion.ShowDialog();

            // Update
            // Index가 안변할경우
            // Version갱신 후 Add
            // Index가 변할경우
            // 변한 Index에 대하여 Version갱신 후 Add 및
            // 바뀌는(밀리거나 당겨지는) 문제들에 대해 변화되는 Index변화 + Version갱신 후 Add

            if (modifyQuestion.IsChaneged)
            {
                modifyQuestion.Question.Version =
                    Dao.Question.GetNewestVersionNumber(AfterQuestions, modifyQuestion.Question.DepartmentID,
                    modifyQuestion.Question.Index) + 1;

                List<Question> questions = new List<Question>();

                if (modifyQuestion.Question.Index < beforeQuestionIndex)
                {
                    for (int i = modifyQuestion.Question.Index;
                        i <= beforeQuestionIndex - 1; i++)
                    {
                        var data = AfterQuestions.FindAll(x => x.Index == i)
                                .OrderByDescending(x => x.Version)
                                .FirstOrDefault();
                        Question question = (Question)data.Clone();
                        question.Index++;
                        question.Version = Dao.Question.GetNewestVersionNumber(AfterQuestions, question.DepartmentID, question.Index) + 1;
                        questions.Add(question);
                    }
                }
                else
                {
                    for (int i = beforeQuestionIndex + 1;
                        i <= modifyQuestion.Question.Index; i++)
                    {
                        var data = AfterQuestions.FindAll(x => x.Index == i)
                                .OrderByDescending(x => x.Version)
                                .FirstOrDefault();
                        Question question = (Question)data.Clone();
                        question.Index--;
                        question.Version = Dao.Question.GetNewestVersionNumber(AfterQuestions, question.DepartmentID, question.Index) + 1;
                        questions.Add(question);
                    }
                }

                foreach (Question item in questions)
                    AfterQuestions.Add(item);

                AfterQuestions.Add(modifyQuestion.Question);
            }

            ReloadGridView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((Question)bdsQuestion.Current == null)
                return;

            if (WinformUtility.AskSure("정말 삭제하시겠습니까? (실제 반영은 일괄저장을 누를 때 반영됩니다)") == false)
                return;

            // Delete
            // 바뀌는(당겨지는) 문제들에 대해 변화되는 Index변화 + Version갱신 후 Add
            // Department테이블 Count값-1

            List<Question> questions = new List<Question>();

            for (int i = ((Question)bdsQuestion.Current).Index + 1;
                i <= (int)Department.Count; i++)
            {
                var data = AfterQuestions.FindAll(x => x.Index == i)
                    .OrderByDescending(x => x.Version)
                    .FirstOrDefault();
                Question question = (Question)data.Clone();
                question.Index--;
                question.Version = Dao.Question.GetNewestVersionNumber(AfterQuestions, question.DepartmentID, question.Index) + 1;
                questions.Add(question);
            }

            foreach (Question item in questions)
                AfterQuestions.Add(item);

            Department.Count--;

            ReloadGridView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 작업하는 사이에 데이터베이스에 변화가 있었나 검사하기 위해 데이터를 가져온다
            List<Question> questions = Dao.Question.GetNewestVersionByDepartmentID(CurrentEmployeeInHere.DepartmentID);

            // 사용한 클래스 간 비교 로직
            //var firstNotSecond = list1.Except(list2).ToList();
            //var secondNotFirst = list2.Except(list1).ToList();
            //return !firstNotSecond.Any() && !secondNotFirst.Any();

            var firstNotSecond = questions.Except(BeforeQuestions).ToList();
            var secondNotFirst = BeforeQuestions.Except(questions).ToList();

            // 있었다면 보내버린다(응?)
            if (!firstNotSecond.Any() && !secondNotFirst.Any() == false)
            {
                MessageBox.Show("서버의 다른 변화를 감지하여 저장을 취소합니다. 처음부터 다시 시도해주세요.");
                btnGoBack.PerformClick();
                return;
            }

            // 트랜잭션 방식으로 수정된 데이터들을 데이베이스에 저장
            using (var context = DKClinicEntities.Create())
            {
                // Department 테이블 업데이트
                context.Entry(Department).State = System.Data.Entity.EntityState.Modified;

                // Question 테이블에 afterQuestion에 추가된 값을 업데이트(Insert)
                for (int i = BeforeQuestions.Count; i < AfterQuestions.Count; i++)
                    context.Questions.Add(AfterQuestions[i]);

                context.SaveChanges();
                btnGoBack.PerformClick();
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            EmployeeSelectFunctionControl employeeSelectFunctionControl = new EmployeeSelectFunctionControl(CurrentEmployeeInHere);
            OnbtnCancelClicked(employeeSelectFunctionControl);
        }
    }
}
