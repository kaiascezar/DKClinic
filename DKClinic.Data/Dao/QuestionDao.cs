using System;
using System.Linq.Expressions;

namespace DKClinic.Data
{
    public class QuestionDao : SingleKeyDao<Question, int>
    {
        protected override Expression<Func<Question, int>> KeySelector => x => x.QuestionID;

        protected override Expression<Func<Question, bool>> IsKey(int key)
        {
            return x => x.QuestionID == key;
        }
    }
}
