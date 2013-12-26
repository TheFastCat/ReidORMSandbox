using Data.Adapter.Contract;
using Data.ORM.Contract;
using System;
using System.Collections.Generic;

namespace Data.Adapter.Legacy.SQLServer
{
    public class SqlServerRepository : IRepository
    {
        public SqlServerRepository(IORM iSalesAppORM)
        {
            _iSalesAppORM = iSalesAppORM;
        }

        private IORM _iSalesAppORM;

        public Type ORM { get { return _iSalesAppORM.GetType(); } }

        /// TODO: implement method injection of stored procedures...
        IEnumerable<dynamic> IRepository.GetAllCustomers()
        {
            return _iSalesAppORM.GetCustomersFromSP("dbo.ObjCustomer");
        }

        IEnumerable<dynamic> IRepository.GetAllAddresses()
        {
            return _iSalesAppORM.GetCustomerAddressesFromSP("dbo.ObjCustomerAddresses");
        }

        IEnumerable<dynamic> IRepository.GetAllPhoneNumbers()
        {
            return _iSalesAppORM.GetCustomerPhoneNumbersFromSP("dbo.ObjCustomerPhones");
        }
    }
}
