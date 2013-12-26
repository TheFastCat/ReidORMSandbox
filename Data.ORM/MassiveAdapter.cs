using Massive;
using Data.ORM.Base;
using Data.ORM.Contract;
using System.Collections.Generic;
using System.Data;

namespace Data.ORM
{
    /// <summary>
    /// Massive ORM implementation of IORM
    /// </summary>
    /// <see cref="https://github.com/robconery/massive/"/>
    /// <remarks>Massive loads the first connection string it finds from the App.config or Web.config file and creates a DB connection from it.</remarks>
    public class MassiveAdapter : ORMDataConnection, IORM
    {
        public MassiveAdapter(IDbConnection dbConnection)
            : base(dbConnection)
        {}

        IEnumerable<dynamic> IORM.GetCustomersFromSP(string storedProcedureName)
        {
            var queried = DB.Current.Query(storedProcedureName);
            return queried;
        }

        IEnumerable<dynamic> IORM.GetCustomerAddressesFromSP(string storedProcedureName)
        {
            var queried = DB.Current.Query(storedProcedureName);
            return queried;
        }

        IEnumerable<dynamic> IORM.GetCustomerPhoneNumbersFromSP(string storedProcedureName)
        {
            var queried = DB.Current.Query(storedProcedureName);
            return queried;
        }
    }
}
