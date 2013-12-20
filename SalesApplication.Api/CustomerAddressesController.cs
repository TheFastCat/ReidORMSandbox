using SalesApplication.Data.Adapter.Contract;
using System.Collections.Generic;
using System.Web.Http;

namespace SalesApplication.Api
{
    /// <summary>
    /// An ApiController retrieving Customers
    /// </summary>
    /// <remarks>TODO: Extend</remarks>
    public class CustomerAddresesController : ApiController
    {
        ISalesAppData _salesAppData;

        public CustomerAddresesController(ISalesAppData salesAppData)
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
