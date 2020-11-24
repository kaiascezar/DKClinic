using System;
using System.Linq.Expressions;

namespace DKClinic.Data
{
    public class GenderDao : SingleKeyDao<Gender, int>
    {
        protected override Expression<Func<Gender, int>> KeySelector => x => x.GenderID;

        protected override Expression<Func<Gender, bool>> IsKey(int key)
        {
            return x => x.GenderID == key;
        }
    }
}
