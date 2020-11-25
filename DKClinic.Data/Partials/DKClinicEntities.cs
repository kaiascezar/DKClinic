using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DKClinic.Data
{
    public partial class DKClinicEntities
    {
		public const string ConnectionString = "metadata=res://*/DKClinic.csdl|res://*/DKClinic.ssdl|res://*/DKClinic.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=kimpro;initial catalog=DKClinic;persist security info=True;user id=sa;password=3512;MultipleActiveResultSets=True;App=EntityFramework&quot;\" providerName=\"System.Data.EntityClient";
		private DKClinicEntities(string connectionString) : base(connectionString)
		{
		}
		public static DKClinicEntities Create()
		{ 
			return new DKClinicEntities(ConnectionString);
		}
		public static void Initialize()
		{ 
			DbContextCreator.Context = () => Create();
		}
	}
}
