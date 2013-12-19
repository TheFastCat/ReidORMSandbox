using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using SalesApplication.Data.Adapter.Contract;

namespace SalesApplication.Api
{
    /// <summary>
    /// An ApiController retrieving Customers
    /// </summary>
    /// <remarks>TODO: Extend</remarks>
    public class CustomerController : ApiController
    {
        ISalesAppData _salesAppData;

        public CustomerController(ISalesAppData salesAppData)
        {
            _salesAppData = salesAppData;
        }

        public IEnumerable<dynamic> Get()
        {
            return _salesAppData.GetAllCustomers();
        }

        [Route("api/customers/")]
        public IEnumerable<dynamic> GetCustomers()
        {
            return Get();
        }
    }
}
