using System;
using System.Linq.Expressions;

namespace DKClinic.Data
{
    public class ResponseDao : SingleKeyDao<Response, int>
    {
        protected override Expression<Func<Response, int>> KeySelector => x => x.ResponseID;

        protected override Expression<Func<Response, bool>> IsKey(int key)
        {
            return x => x.ResponseID == key;
        }
    }
}
