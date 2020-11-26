using System;
using System.Linq;
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

        public Employee Find(string name)
        {
            using (var context = DKClinicEntities.Create())
            {
                return context.Employees.Where(x => x.Name == name)
                                        .FirstOrDefault();
            }
        }
    }
}
