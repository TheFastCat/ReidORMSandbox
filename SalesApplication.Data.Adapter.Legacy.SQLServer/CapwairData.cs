using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApplication.Data.Contract;
using SalesApplication.Data.ORM.Contract;
using SalesApplication.Data.Adapter.Contract;
using SalesApplication.Data.Model;

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


        public IList<Customer> GetAllCustomers()
        {
            return _iSalesAppORM.GetCustomers("dbo.ObjCustomer");
        }
    }
}
