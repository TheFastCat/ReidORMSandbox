using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApplication.Data.ORM.Contract;
using SalesApplication.Data.Contract;
using Dapper;
using SalesApplication.Data.Model;


namespace SalesApplication.Data.ORM
{
    public class DapperAdapter : ORMDataConnection, ISalesAppORM, IDataConnection
    {
        public DapperAdapter(string connectionStr): base(connectionStr)
        {
            //todo: initialize construction of Dapper required components...
        }

        public IList<Customer> GetCustomers(string storedProcedureName)
        {
            throw new NotImplementedException();

            //TODO - add impl required for Dapper to Load Customers from the DB...
            
            //var customers = 
        }
    }
}
