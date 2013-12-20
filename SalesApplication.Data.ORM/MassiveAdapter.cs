using Massive;
using SalesApplication.Data.ORM.Base;
using SalesApplication.Data.ORM.Contract;
using System.Collections.Generic;
using System.Data;

namespace SalesApplication.Data.ORM
{
    /// <summary>
    /// Massive ORM implementation of ISalesAppORM
    /// </summary>
    /// <see cref="https://github.com/robconery/massive/"/>
    /// <remarks>Massive loads the first connection string it finds from the App.config or Web.config file and creates a DB connection from it.</remarks>
    public class MassiveAdapter : ORMDataConnection, ISalesAppORM
    {
        public MassiveAdapter(IDbConnection dbConnection)
            : base(dbConnection)
        {}

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
