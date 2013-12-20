using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApplication.Data.ORM.Contract;
using SalesApplication.Data.ORM.Base;
using System.Data;
using System.Data.SqlClient;
using Massive;

namespace SalesApplication.Data.ORM
{
    public class MassiveAdapter : ORMDataConnection, ISalesAppORM
    {
        public MassiveAdapter(IDbConnection dbConnection)
            : base(dbConnection)
        {
            //todo: initialize any construction of Massive required components...
        }

        IEnumerable<dynamic> ISalesAppORM.GetCustomersFromSP(string storedProcedureName)
        {
            var queried = DB.Current.Query(storedProcedureName);
            return queried;
        }

        IEnumerable<dynamic> ISalesAppORM.GetCustomerAddressesFromSP(string storedProcedureName)
        {
            var queried = DB.Current.Query(storedProcedureName);
            return queried;
        }

        IEnumerable<dynamic> ISalesAppORM.GetCustomerPhoneNumbersFromSP(string storedProcedureName)
        {
            var queried = DB.Current.Query(storedProcedureName);
            return queried;
        }
    }
}
