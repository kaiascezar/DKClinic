using System;
using System.Linq.Expressions;

namespace DKClinic.Data
{
    public class PositionDao : SingleKeyDao<Position, int>
    {
        protected override Expression<Func<Position, int>> KeySelector => x => x.PositionID;

        protected override Expression<Func<Position, bool>> IsKey(int key)
        {
            return x => x.PositionID == key;
        }
    }
}
