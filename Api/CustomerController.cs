using Data.Adapter.Contract;
using System.Collections.Generic;
using System.Web.Http;

namespace Api
{
    /// <summary>
    /// An ApiController retrieving Customers
    /// </summary>
    /// <remarks>TODO: Extend</remarks>
    public class CustomerController : ApiController
    {
        IRepository _salesAppData;

        public CustomerController(IRepository salesAppData)
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
