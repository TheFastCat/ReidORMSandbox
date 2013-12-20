using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApplication.Data.ORM.Contract
{
    public interface ISalesAppORM
    {
        IEnumerable<dynamic> GetCustomersFromSP(string storedProcedureName);
        IEnumerable<dynamic> GetCustomerAddressesFromSP(string storedProcedureName);
        IEnumerable<dynamic> GetCustomerPhoneNumbersFromSP(string storedProcedureName);
    }
}
