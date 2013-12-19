using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApplication.Data.ORM.Contract;
using Dapper;
using SalesApplication.Data.Model;
using System.Data.SqlClient;
using System.Data;


namespace SalesApplication.Data.ORM
{
    public class DapperAdapter : ORMDataConnection, ISalesAppORM
    {
        public DapperAdapter(IDbConnection dbConnection)
            : base(dbConnection)
        {
            //todo: initialize any construction of Dapper required components...
        }

        public IList<Customer> GetCustomersFromSP(string storedProcedureName)
        {
            IList<Customer> toReturn = null;

            try
            {
                DbConnection.Open();
                var customers = DbConnection.Query<Customer>(storedProcedureName, commandType: CommandType.StoredProcedure);
                toReturn = new List<Customer>(customers);
            }
            catch(Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                DbConnection.Close();
            }

            return toReturn;
        }

        public IList<Address> GetCustomerAddressesFromSP(string storedProcedureName)
        {
            IList<Address> toReturn = null;

            try
            {
                DbConnection.Open();
                var addresses = DbConnection.Query<Address>(storedProcedureName, commandType: CommandType.StoredProcedure);
                toReturn = new List<Address>(addresses);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                DbConnection.Close();
            }

            return toReturn;
        }

        public IList<PhoneNumber> GetCustomerPhoneNumbersFromSP(string storedProcedureName)
        {
            IList<PhoneNumber> toReturn = null;

            try
            {
                DbConnection.Open();
                var phoneNumbers = DbConnection.Query<PhoneNumber>("ObjCustomer", commandType: CommandType.StoredProcedure);
                toReturn = new List<PhoneNumber>(phoneNumbers);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                DbConnection.Close();
            }

            return toReturn;
        }
    }
}
