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
    public class CustomerPhonesController : ApiController
    {
        ISalesAppData _salesAppData;

        public CustomerPhonesController(ISalesAppData salesAppData)
        {
            _salesAppData = salesAppData;
        }

        public IEnumerable<dynamic> Get()
        {
            return _salesAppData.GetAllPhoneNumbers();
        }

        [Route("api/customers/phoneNumbers")]
        public IEnumerable<dynamic> GetPhoneNumbers()
        {
            return Get();
        }
    }
}
