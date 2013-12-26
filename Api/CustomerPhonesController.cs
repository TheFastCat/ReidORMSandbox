using Data.Adapter.Contract;
using System.Collections.Generic;
using System.Web.Http;

namespace Api
{
    /// <summary>
    /// An ApiController retrieving Customers
    /// </summary>
    /// <remarks>TODO: Extend</remarks>
    public class CustomerPhonesController : ApiController
    {
        IRepository _salesAppData;

        public CustomerPhonesController(IRepository salesAppData)
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
