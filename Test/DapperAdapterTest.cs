using NUnit.Framework;
using SalesApplication.Data.ORM;
using SalesApplication.Data.ORM.Contract;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Test
{
    /// <summary>
    /// [TestFixture] for SalesApplication.Data.ORM.DapperAdapter
    /// </summary>
    [Category("LocalIntegration")]
    [TestFixture]
    public class DapperAdapterTest
    {
        ISalesAppORM _iSalesAppORM;
        private string CONNECTION_STRING;
        private readonly string CONFIGURATION_CONNECTION_STRING = "Capwair.Test";

        [TestFixtureSetUp]
        public void TextFixtureSetup()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CONNECTION_STRING = ConfigurationManager.ConnectionStrings[CONFIGURATION_CONNECTION_STRING].ConnectionString;
            _iSalesAppORM = new DapperAdapter(new SqlConnection(CONNECTION_STRING));
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
        }

        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Description("ORM integration test")]
        [Test, Explicit]
        public void DapperIntegrationTest()
        {
            Assert.IsNotNull(_iSalesAppORM);
            Assert.IsInstanceOf<DapperAdapter>(_iSalesAppORM);

            IEnumerable<dynamic> customers = _iSalesAppORM.GetCustomersFromSP("ObjCustomer");
            Assert.IsNotNull(customers);
            Assert.Greater(customers.ToList().Count(), 0);

            IEnumerable<dynamic> addresses = _iSalesAppORM.GetCustomerAddressesFromSP("ObjCustomerAddresses");
            Assert.IsNotNull(addresses);
            Assert.Greater(addresses.ToList().Count(), 0);

            IEnumerable<dynamic> phoneNumbers = _iSalesAppORM.GetCustomerPhoneNumbersFromSP("ObjCustomerPhones");
            Assert.IsNotNull(phoneNumbers);
            Assert.Greater(phoneNumbers.ToList().Count(), 0);
        }
    }
}
