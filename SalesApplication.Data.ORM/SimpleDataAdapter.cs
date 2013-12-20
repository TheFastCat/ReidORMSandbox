using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApplication.Data.ORM.Contract;
using Simple.Data.SqlServer;
using SalesApplication.Data.ORM.Base;
using Simple.Data;

namespace SalesApplication.Data.ORM
{
    public class SimpleDataAdapter : ORMDataConnection, ISalesAppORM
    {
        IEnumerable<dynamic> ISalesAppORM.GetCustomersFromSP(string storedProcedureName)
        {
            //throw new NotImplementedException();
            var db = Database.Open();
            return db.dbo.ObjCustomer();
        }

        IEnumerable<dynamic> ISalesAppORM.GetCustomerAddressesFromSP(string storedProcedureName)
        {
            throw new NotImplementedException();
        }

        IEnumerable<dynamic> ISalesAppORM.GetCustomerPhoneNumbersFromSP(string storedProcedureName)
        {
            throw new NotImplementedException();
        }

        static string GetName<T>(T item) where T : class
        {
            var properties = typeof(T).GetProperties();
            return properties[0].Name;
        }
    }
}
