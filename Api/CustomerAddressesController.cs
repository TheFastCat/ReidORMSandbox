using Data.Adapter.Contract;
using System.Collections.Generic;
using System.Web.Http;

namespace Api
{
    /// <summary>
    /// An ApiController retrieving Customers
    /// </summary>
    /// <remarks>TODO: Extend</remarks>
    public class CustomerAddresesController : ApiController
    {
        IRepository _salesAppData;

        public CustomerAddresesController(IRepository salesAppData)
        {
            _salesAppData = salesAppData;
        }

        public IEnumerable<dynamic> Get()
        {
            return _salesAppData.GetAllAddresses();
        }

        [Route("api/customers/addresses")]
        public IEnumerable<dynamic> GetAddresses()
        {
            return Get();
        }
    }
}
