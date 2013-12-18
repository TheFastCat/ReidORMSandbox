using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApplication.Data.Contract;
using SalesApplication.Data.Model;

namespace SalesApplication.Data.ORM.Contract
{
    public interface ISalesAppORM
    {
        IList<Customer> GetCustomers(string storedProcedureName);
    }
}
