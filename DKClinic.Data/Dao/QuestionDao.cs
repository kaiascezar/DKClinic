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

        public List<Question> GetWithDepartmentAndTypeName()
        {
            List<Question> questions = Dao.Question.GetAll();
            return ConvertDepartmentAndTypeName(questions);
        }

        public List<Question> GetWihDepartmentAndTypeNameByDepartmentID(int depatmentID)
        {
            List<Question> questions = Dao.Question.GetByDepartmentID(depatmentID);
            return ConvertDepartmentAndTypeName(questions);
        }

        public List<Question> ConvertDepartmentAndTypeName(List<Question> questions)
        {
            using (var context = DKClinicEntities.Create())
            {
                foreach (Question question in questions)
                {
                    var query = context.Questions
                        .Where(x => x.QuestionID == question.QuestionID)
                        .Select(x => x.Department.Name)
                        .FirstOrDefault();
                    question.DepartmentName = query.ToString();
    
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

        public List<Question> GetByNewestVersion()
        {
            List<Question> questions = Dao.Question.GetWithDepartmentAndTypeName();
            return SelectionNewestVersion(questions);
        }

        public List<Question> GetByNewestVersionByDepartmentID(int departmentID)
        {
            List<Question> questions = Dao.Question.GetWihDepartmentAndTypeNameByDepartmentID(departmentID);
            return SelectionNewestVersionByDepartmentID(questions, departmentID);
        }

        public List<Question> GetByDepartmentIDAndIndex(int departmentID, int index)
        {
            using (var context = DKClinicEntities.Create())
            {
                var query = context.Questions
                    .Where(x => x.DepartmentID == departmentID && x.Index == index)
                    .Select(x => x);

                return query.ToList();
            }
        }

        public int GetNewestVersionNumber(int departmentId, int index)
        {
            List<Question> questions = GetByDepartmentIDAndIndex(departmentId, index);
            return questions.OrderByDescending(x => x.Version).ToList()[0].Index;
        }

        public List<Question> SelectionNewestVersion(List<Question> questions, int departmentID=0)
        {
            int maxDepartment;
            List<Question> resultList = new List<Question>();

            if (departmentID == 0)
                maxDepartment = Dao.Department.GetCount();
            else
                maxDepartment = departmentID;

            for(int i = (departmentID != 0 ? departmentID : 1); i <= maxDepartment; i++)
            {
                for(int j = 1; j <= Dao.Department.GetQuestionCount(i); j++)
                {
                    List<Question> list = questions.FindAll(x => x.DepartmentID == i && x.Index == j);
                    resultList.Add(list.OrderByDescending(x => x.Version).ToList()[0]);
                }
            }

            return resultList;
        }

        public List<Question> SelectionNewestVersionByDepartmentID(List<Question> questions, int departmentID)
        {
            return SelectionNewestVersion(questions, departmentID);
        }
    }
}
