using System;
using System.Linq.Expressions;

namespace DKClinic.Data
{
    public class CustomerDao : SingleKeyDao<Customer, int>
    {
        protected override Expression<Func<Customer, int>> KeySelector => x => x.CustomerID;

        protected override Expression<Func<Customer, bool>> IsKey(int key)
        {
            return x => x.CustomerID == key;
        }
    }
}
