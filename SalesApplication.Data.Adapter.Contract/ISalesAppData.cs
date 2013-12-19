using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApplication.Data.Model;

namespace SalesApplication.Data.Adapter.Contract
{
    /// <summary>
    /// This interface abstracts all data-retrieval operations required by the SalesApplication
    /// </summary>
    public interface ISalesAppData
    {
        Type ORM { get; }
        
        // TODO define all data operations wanted/needed by the SalesApplication
        IList<Customer> GetAllCustomers();

        IList<Address> GetAllAddresses();

        IList<PhoneNumber> GetAllPhoneNumbers();
    }
}
