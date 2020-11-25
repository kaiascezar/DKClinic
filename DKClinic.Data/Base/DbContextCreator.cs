using System;
using System.Data.Entity;

namespace DKClinic.Data
{
    public class DbContextCreator
    {
        public static Func<DbContext> Context { get; set; }
    }
}
