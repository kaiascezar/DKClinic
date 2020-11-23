using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKClinic.Data
{
    class BaseDao<T> where T : class
    {
        public int GetCount()
        {
            using (var context = DbContextCreator.Context())
            {
                return context.Set<T>().Count();
            }
        }

        public List<T> GetAll()
        {
            using (var context = DbContextCreator.Context())
            {
                return context.Set<T>().ToList();
            }
        }

        public void Insert(T entity)
        {
            using (var context = DbContextCreator.Context())
            {
                context.Set<T>().Add(entity);

                context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (var context = DbContextCreator.Context())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = DbContextCreator.Context())
            {
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;

                context.SaveChanges();
            }
        }
    }
}
