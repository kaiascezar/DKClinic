using System;
using System.Linq.Expressions;
using System.Linq;
using System.Collections.Generic;

namespace DKClinic.Data
{
    public class QuestionDao : SingleKeyDao<Question, int>
    {
        protected override Expression<Func<Question, int>> KeySelector => x => x.QuestionID;

        protected override Expression<Func<Question, bool>> IsKey(int key)
        {
            return x => x.QuestionID == key;
        }

        // 진료과에 해당하는 Questino 테이블의 값을 전달받는 메서드
        public List<Question> GetByDepartmentID(int departmentID)
        {
            using(var context = DKClinicEntities.Create())
            {
                var query = context.Questions
                    .Where(x => x.DepartmentID == departmentID)
                    .Select(x => x);

                return query.ToList();
            }
        }

        // Question 테이블의 값을 DepartmentName과 TypeName값을 추가하여 전달받는 메서드
        public List<Question> GetWithDepartmentAndTypeNameByDepartmentID(int depatmentID)
        {
            List<Question> questions = Dao.Question.GetByDepartmentID(depatmentID);
            return AddDepartmentNameAndTypeName(questions);
        }

        // 전달받은 리스트의 값에 DepartmentName과 TypeName값을 추가해주는 메서드
        public List<Question> AddDepartmentNameAndTypeName(List<Question> questions)
        {
            using (var context = DKClinicEntities.Create())
            {
                List<Department> departments = Dao.Department.GetAll();

                foreach (Question question in questions)
                {
                    question.DepartmentName = departments
                        .Where(x => x.DepartmentID == question.DepartmentID)
                        .Select(x => x.Name).FirstOrDefault();

                    if (question.Type == 1)
                        question.TypeName = "주관식";
                    else if (question.Type == 2)
                        question.TypeName = "객관식";
                    else if (question.Type == 3)
                        question.TypeName = "객관식(다중선택)";
                }
            }

            return questions;
        }

        // 전달받은 리스트에서 진료과 및 인덱스에 해당하는 문제의 최신 버전 번호를 구하는 메서드
        public int GetNewestVersionNumber(List<Question> questions, int departmentId, int index)
        {
            List<Question> questionsList = SelectionByDepartmentIDAndIndex(questions, departmentId, index);
            if (questionsList.Count == 0) return 0;
            return questionsList.OrderByDescending(x => x.Version).ToList()[0].Version;
        }

        // 전달받은 리스트에서 진료과 및 인덱스에 해당하는 문제 리스트를 구하는 메서드
        public List<Question> SelectionByDepartmentIDAndIndex(List<Question> questions, int departmentID, int index)
        {
            var query = questions
                .Where(x => x.DepartmentID == departmentID && x.Index == index)
                .Select(x => x);

            return query.ToList();
        }

        // 진료과에 해당하는 최신 버전 문제 리스트를 구하는 메서드
        public List<Question> GetNewestVersionByDepartmentID(int departmentID)
        {
            List<Question> questions = Dao.Question.GetWithDepartmentAndTypeNameByDepartmentID(departmentID);
            return SelectionNewestVersionByDepartmentID(questions, departmentID);
        }

        // 전달받은 리스트에서 진료과에 해당하는 최신 버전 문제 리스트를 구하는 메서드
        public List<Question> SelectionNewestVersionByDepartmentID(List<Question> questions, int departmentID)
        {
            List<Question> resultList = new List<Question>();

            for (int j = 1; j <= Dao.Department.GetQuestionCount(departmentID); j++)
            {
                List<Question> list = questions.FindAll(x => x.DepartmentID == departmentID && x.Index == j);
                resultList.Add(list.OrderByDescending(x => x.Version).ToList()[0]);
            }

            return resultList;
        }

        // 전달받은 리스트에서 전달받은 진료과에 해당하는 최신 버전 문제 리스트를 구하는 메서드
        public List<Question> SelectionNewestVersionByLocalDepartment(List<Question> questions, Department department)
        {
            int maxDepartment = (int)department.Count;
            List<Question> resultList = new List<Question>();

            for (int j = 1; j <= department.Count; j++)
            {
                List<Question> list = questions.FindAll(x => x.DepartmentID == department.DepartmentID && x.Index == j);
                resultList.Add(list.OrderByDescending(x => x.Version).ToList()[0]);
            }

            return resultList;
        }
    }
}
