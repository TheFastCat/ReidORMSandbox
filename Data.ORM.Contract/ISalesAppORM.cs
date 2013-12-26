using System.Collections.Generic;

namespace Data.ORM.Contract
{
    public interface IORM
    {
        IEnumerable<dynamic> GetCustomersFromSP(string storedProcedureName);
        IEnumerable<dynamic> GetCustomerAddressesFromSP(string storedProcedureName);
        IEnumerable<dynamic> GetCustomerPhoneNumbersFromSP(string storedProcedureName);
    }
}
