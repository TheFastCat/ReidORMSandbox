using System;
using System.Collections.Generic;

namespace Data.Adapter.Contract
{
    /// <summary>
    /// This interface abstracts all data-retrieval operations required by the SalesApplication
    /// </summary>
    public interface IRepository
    {
        // TODO define all data operations wanted/needed by the SalesApplication
        IEnumerable<dynamic> GetAllCustomers();

        IEnumerable<dynamic> GetAllAddresses();

        IEnumerable<dynamic> GetAllPhoneNumbers();

        Type ORM { get; }
    }
}
