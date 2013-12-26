using Dapper;
using Data.ORM.Base;
using Data.ORM.Contract;
using System;
using System.Collections.Generic;
using System.Data;

namespace Data.ORM
{
    /// <summary>
    /// Dapper ORM implementation of IORM
    /// </summary>
    /// <see cref="https://code.google.com/p/dapper-dot-net/"/>
    /// <remarks>Dapper adds ORM extension methods to the IDBConnection interface</remarks>
    public class DapperAdapter : ORMDataConnection, IORM
    {
        public DapperAdapter(IDbConnection dbConnection)
            : base(dbConnection)
        {}

        IEnumerable<dynamic> IORM.GetCustomersFromSP(string storedProcedureName)
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

        IEnumerable<dynamic> IORM.GetCustomerAddressesFromSP(string storedProcedureName)
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

        IEnumerable<dynamic> IORM.GetCustomerPhoneNumbersFromSP(string storedProcedureName)
        {
            IEnumerable<dynamic> phoneNumbers = null; 

            try
            {
                DbConnection.Open();
                phoneNumbers = DbConnection.Query(storedProcedureName, commandType: CommandType.StoredProcedure);
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
