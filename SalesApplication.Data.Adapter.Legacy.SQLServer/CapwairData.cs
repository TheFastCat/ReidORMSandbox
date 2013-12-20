using SalesApplication.Data.Adapter.Contract;
using SalesApplication.Data.ORM.Contract;
using System;
using System.Collections.Generic;

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
