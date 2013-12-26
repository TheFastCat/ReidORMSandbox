using NUnit.Framework;
using Data.Adapter.Contract;
using Data.Adapter.Legacy.SQLServer;
using Data.ORM;
using Data.ORM.Contract;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Test
{
    /// <summary>
    /// [TestFixture] for Data.Adapter.Legacy.SQLServer.CapwairData
    /// </summary>
    [TestFixture]
    public class SQLServerRepositoryTest
    {
        IRepository _appRepository;
        private string CONNECTION_STRING;
        private readonly string CONFIGURATION_CONNECTION_STRING = "Capwair.Test";

        [TestFixtureSetUp]
        public void TextFixtureSetup()
        {
            // manually inject ORM into ctor...
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CONNECTION_STRING = ConfigurationManager.ConnectionStrings[CONFIGURATION_CONNECTION_STRING].ConnectionString;
            IORM iORM = new MassiveAdapter(new SqlConnection(CONNECTION_STRING));
            _appRepository = new SqlServerRepository(iORM);
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
            Assert.IsNotNull(_appRepository);
            Assert.IsInstanceOf<SqlServerRepository>(_appRepository);
            Assert.AreEqual(typeof(MassiveAdapter), _appRepository.ORM);
        }

        [Description("End-to-end integration test")]
        [Category("LocalIntegration")]
        [Test, Explicit]
        public void IntegrationTest()
        {
            IEnumerable<dynamic> customers = _appRepository.GetAllCustomers();
            Assert.IsNotNull(customers);
            Assert.Greater(customers.ToList().Count(), 0);

            IEnumerable<dynamic> addresses = _appRepository.GetAllAddresses();
            Assert.IsNotNull(addresses);
            Assert.Greater(addresses.ToList().Count(), 0);

            IEnumerable<dynamic> phoneNumbers = _appRepository.GetAllPhoneNumbers();
            Assert.IsNotNull(phoneNumbers);
            Assert.Greater(phoneNumbers.ToList().Count(), 0);
        }
    }
}
