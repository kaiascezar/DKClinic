using System;
using System.Linq.Expressions;

namespace DKClinic.Data
{
    public class QuestionnareDao : SingleKeyDao<Questionnare, int>
    {
        protected override Expression<Func<Questionnare, int>> KeySelector => x => x.QuestionnareID;

        protected override Expression<Func<Questionnare, bool>> IsKey(int key)
        {
            return x => x.QuestionnareID == key;
        }
    }
}
