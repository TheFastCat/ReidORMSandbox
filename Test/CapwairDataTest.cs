using NUnit.Framework;
using SalesApplication.Data.Adapter.Contract;
using SalesApplication.Data.Adapter.Legacy.SQLServer;
using SalesApplication.Data.ORM;
using SalesApplication.Data.ORM.Contract;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Test
{
    /// <summary>
    /// [TestFixture] for SalesApplication.Data.Adapter.Legacy.SQLServer.CapwairData
    /// </summary>
    [TestFixture]
    public class CapwairDataTest
    {
        ISalesAppData _salesAppData;
        private string CONNECTION_STRING;
        private readonly string CONFIGURATION_CONNECTION_STRING = "Capwair.Test";

        [TestFixtureSetUp]
        public void TextFixtureSetup()
        {
            // manually inject ORM into ctor...
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CONNECTION_STRING = ConfigurationManager.ConnectionStrings[CONFIGURATION_CONNECTION_STRING].ConnectionString;
            ISalesAppORM iSalesAppORM = new MassiveAdapter(new SqlConnection(CONNECTION_STRING));
            _salesAppData = new CapwairData(iSalesAppORM);
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

        [Test]
        public void CompositionTest()
        {
            Assert.IsNotNull(_salesAppData);
            Assert.IsInstanceOf<CapwairData>(_salesAppData);
            Assert.AreEqual(typeof(MassiveAdapter), _salesAppData.ORM);
        }

        [Description("End-to-end integration test")]
        [Category("LocalIntegration")]
        [Test, Explicit]
        public void IntegrationTest()
        {
            IEnumerable<dynamic> customers = _salesAppData.GetAllCustomers();
            Assert.IsNotNull(customers);
            Assert.Greater(customers.ToList().Count(), 0);

            IEnumerable<dynamic> addresses = _salesAppData.GetAllAddresses();
            Assert.IsNotNull(addresses);
            Assert.Greater(addresses.ToList().Count(), 0);

            IEnumerable<dynamic> phoneNumbers = _salesAppData.GetAllPhoneNumbers();
            Assert.IsNotNull(phoneNumbers);
            Assert.Greater(phoneNumbers.ToList().Count(), 0);
        }
    }
}
