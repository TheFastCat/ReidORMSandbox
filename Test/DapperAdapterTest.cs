using NUnit.Framework;
using Data.ORM;
using Data.ORM.Contract;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Test
{
    /// <summary>
    /// [TestFixture] for Data.ORM.DapperAdapter
    /// </summary>
    [Category("LocalIntegration")]
    [TestFixture]
    public class DapperAdapterTest
    {
        IORM _iORM;
        private string CONNECTION_STRING;
        private readonly string CONFIGURATION_CONNECTION_STRING = "Capwair.Test";

        [TestFixtureSetUp]
        public void TextFixtureSetup()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CONNECTION_STRING = ConfigurationManager.ConnectionStrings[CONFIGURATION_CONNECTION_STRING].ConnectionString;
            _iORM = new DapperAdapter(new SqlConnection(CONNECTION_STRING));
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
        [Category("LocalIntegration")]
        [Test, Explicit]
        public void DapperIntegrationTest()
        {
            Assert.IsNotNull(_iORM);
            Assert.IsInstanceOf<DapperAdapter>(_iORM);

            IEnumerable<dynamic> customers = _iORM.GetCustomersFromSP("ObjCustomer");
            Assert.IsNotNull(customers);
            Assert.Greater(customers.ToList().Count(), 0);

            IEnumerable<dynamic> addresses = _iORM.GetCustomerAddressesFromSP("ObjCustomerAddresses");
            Assert.IsNotNull(addresses);
            Assert.Greater(addresses.ToList().Count(), 0);

            IEnumerable<dynamic> phoneNumbers = _iORM.GetCustomerPhoneNumbersFromSP("ObjCustomerPhones");
            Assert.IsNotNull(phoneNumbers);
            Assert.Greater(phoneNumbers.ToList().Count(), 0);
        }
    }
}
