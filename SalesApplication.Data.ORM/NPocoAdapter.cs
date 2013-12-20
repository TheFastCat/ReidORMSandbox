using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApplication.Data.ORM.Contract;
using SalesApplication.Data.ORM.Base;
using NPoco;
using System.Data;

namespace SalesApplication.Data.ORM
{
    public class NPocoAdapter : ORMDataConnection, ISalesAppORM
    {
        public NPocoAdapter(IDbConnection dbConnection)
            : base(dbConnection)
        {
            //todo: initialize any construction of NPoco required components...
        }

        IEnumerable<dynamic> ISalesAppORM.GetCustomersFromSP(string storedProcedureName)
        {
            throw new NotImplementedException();
        }

        IEnumerable<dynamic> ISalesAppORM.GetCustomerAddressesFromSP(string storedProcedureName)
        {
            throw new NotImplementedException();
        }

        IEnumerable<dynamic> ISalesAppORM.GetCustomerPhoneNumbersFromSP(string storedProcedureName)
        {
            throw new NotImplementedException();
        }
    }
}
