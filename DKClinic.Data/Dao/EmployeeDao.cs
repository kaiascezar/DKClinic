using System;
using System.Linq.Expressions;

namespace DKClinic.Data
{
    public class EmployeeDao : SingleKeyDao<Employee, int>
    {
        protected override Expression<Func<Employee, int>> KeySelector => x => x.EmployeeID;

        protected override Expression<Func<Employee, bool>> IsKey(int key)
        {
            return x => x.EmployeeID == key;
        }
    }
}
