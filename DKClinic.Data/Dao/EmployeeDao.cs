using System;
using System.Collections.Generic;
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

        public List<Employee> GetWithDepartmentAndPositionName()
        {
            using (var context = DKClinicEntities.Create())
            {
                var query = from x in context.Employees
                            select new { Employee = x, DepartmentName = x.Department.Name, PositionName = x.Position.Name };
                var list = query.ToList();

                foreach (var item in list)
                {
                    item.Employee.DepartmentName = item.DepartmentName;
                    item.Employee.PositionName = item.PositionName;
                }

                return list.ConvertAll(x => x.Employee);
            }
        }

        public List<Customer> GetGenderWithGenderID()
        {
            using(var context = DKClinicEntities.Create())
            {
                var query = from x in context.Customers
                            select new { Customer = x, GenderName = x.Gender.Name };
                var list = query.ToList();

                foreach(var item in list)
                {
                    item.Customer.Gender.Name= item.GenderName;
                }
                return list.ConvertAll(x => x.Customer);
            }
        }
    }
}
