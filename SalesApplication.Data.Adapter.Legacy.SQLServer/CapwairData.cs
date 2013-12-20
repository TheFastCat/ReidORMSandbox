using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApplication.Data.ORM.Contract;
using SalesApplication.Data.Adapter.Contract;

namespace SalesApplication.Data.Adapter.Legacy.SQLServer
{
    public class CapwairData : ISalesAppData
    {
        public CapwairData(ISalesAppORM iSalesAppORM)
        {
            _iSalesAppORM = iSalesAppORM;
        }

        private ISalesAppORM _iSalesAppORM;

        public Type ORM { get { return _iSalesAppORM.GetType(); } }

        /// TODO: implement method injection of stored procedures...
        IEnumerable<dynamic> ISalesAppData.GetAllCustomers()
        {
            return _iSalesAppORM.GetCustomersFromSP("dbo.ObjCustomer");
        }

        IEnumerable<dynamic> ISalesAppData.GetAllAddresses()
        {
            return _iSalesAppORM.GetCustomerAddressesFromSP("dbo.ObjCustomerAddresses");
        }

        IEnumerable<dynamic> ISalesAppData.GetAllPhoneNumbers()
        {
            return _iSalesAppORM.GetCustomerPhoneNumbersFromSP("dbo.ObjCustomerPhones");
        }
    }
}
