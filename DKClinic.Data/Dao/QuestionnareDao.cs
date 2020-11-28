using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace DKClinic.Data
{
    public class QuestionnareDao : SingleKeyDao<Questionnare, int>
    {
        protected override Expression<Func<Questionnare, int>> KeySelector => x => x.QuestionnareID;

        protected override Expression<Func<Questionnare, bool>> IsKey(int key)
        {
            return x => x.QuestionnareID == key;
        }

        public List<Questionnare> GetWithDepartmentAndCustomerName(Employee employee)
        {
            using (var context = DKClinicEntities.Create())
            {
                var query = from x in context.Questionnares
                            where x.DepartmentID == employee.DepartmentID
                            select new { Questionnare = x, DepartmentName = x.Department.Name, 
                                CustomerName = x.Customer.Name };
                var list = query.ToList();

                foreach (var item in list)
                {
                    item.Questionnare.DepartmentName = item.DepartmentName;
                    item.Questionnare.CustomerName = item.CustomerName;
                }
                return list.ConvertAll(x => x.Questionnare);
            }
        }
    }
}
