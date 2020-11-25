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

        public List<Question> GetQuestions(int departmentId)
        {
            using(var context = DKClinicEntities.Create())
            {
                var query = context.Questions
                    .Where(x => x.DepartmentID == departmentId)
                    .Select(x => x);

                return query.ToList();
            }
        }
    }
}
