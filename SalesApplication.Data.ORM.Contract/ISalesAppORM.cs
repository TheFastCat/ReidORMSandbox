using System.Collections.Generic;

namespace SalesApplication.Data.ORM.Contract
{
    public interface ISalesAppORM
    {
        IEnumerable<dynamic> GetCustomersFromSP(string storedProcedureName);
        IEnumerable<dynamic> GetCustomerAddressesFromSP(string storedProcedureName);
        IEnumerable<dynamic> GetCustomerPhoneNumbersFromSP(string storedProcedureName);
    }
}
