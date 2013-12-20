using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApplication.Data.ORM.Contract;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using SalesApplication.Data.ORM.Base;


namespace SalesApplication.Data.ORM
{
    public class DapperAdapter : ORMDataConnection, ISalesAppORM
    {
        public DapperAdapter(IDbConnection dbConnection)
            : base(dbConnection)
        {
            //todo: initialize any construction of Dapper required components...
        }

        IEnumerable<dynamic> ISalesAppORM.GetCustomersFromSP(string storedProcedureName)
        {
            IEnumerable<dynamic> customers = null; 

            try
            {
                DbConnection.Open();
                customers = DbConnection.Query(storedProcedureName, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                DbConnection.Close();
            }

            return customers;
        }

        IEnumerable<dynamic> ISalesAppORM.GetCustomerAddressesFromSP(string storedProcedureName)
        {
            IEnumerable<dynamic> addresses = null; 

            try
            {
                DbConnection.Open();
                addresses = DbConnection.Query(storedProcedureName, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                DbConnection.Close();
            }

            return addresses;
        }

        IEnumerable<dynamic> ISalesAppORM.GetCustomerPhoneNumbersFromSP(string storedProcedureName)
        {
            IEnumerable<dynamic> phoneNumbers = null; 

            try
            {
                DbConnection.Open();
                phoneNumbers = DbConnection.Query("ObjCustomer", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                DbConnection.Close();
            }

            return phoneNumbers;
        }
    }
}
