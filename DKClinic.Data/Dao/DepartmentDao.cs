using System;
using System.Linq.Expressions;

namespace DKClinic.Data
{
    public class DepartmentDao : SingleKeyDao<Department, int>
    {
        protected override Expression<Func<Department, int>> KeySelector => x => x.DepartmentID;

        protected override Expression<Func<Department, bool>> IsKey(int key)
        {
            return x => x.DepartmentID == key;
        }

        public int GetQuestionCount(int key)
        {
            return (int)Dao.Department.GetByPK(key).Count;
        }
    }
}
