using System;
using System.Collections.Generic;
using System.Linq;
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

        public Customer Find(string name, string birthdate)
        {
            using (var context = DKClinicEntities.Create())
            {
                return context.Customers.Where(x => x.Name == name && x.Birthdate == birthdate)
                                        .FirstOrDefault();
            }
        }

        public List<Customer> GetByName(string name)
        {
            using (var context = DKClinicEntities.Create())
            {
                var query = from x in context.Customers
                            select new { Customer = x, SearchName = x.Name, GenderName = x.Gender.Name};
                query = query.Where(x => x.Customer.Name == name);

                var list = query.ToList();
                foreach (var item in list)
                {
                    item.Customer.GenderName = item.GenderName;
                }

                return list.ConvertAll(x => x.Customer);
            }
        }

        public List<Customer> GetWithGenderName()
        {
            using (var context = DKClinicEntities.Create())
            {
                var query = from x in context.Customers
                            select new { Customer = x, GenderName = x.Gender.Name };
                var list = query.ToList();

                foreach (var item in list)
                {
                    item.Customer.GenderName = item.GenderName;
                }
                return list.ConvertAll(x => x.Customer);
            }
        }

        
    }
}
