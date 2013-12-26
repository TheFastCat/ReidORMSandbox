using NUnit.Framework;
using Api;
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
    /// [TestFixture] for SalesAppORMDapperImpl
    /// </summary>
    [TestFixture]
    public class ApiTest
    {
        CustomerController         _customersController;
        CustomerAddresesController _customerAddressController;
        CustomerPhonesController   _customerPhonesController;

        IRepository _appRepository;
        private string CONNECTION_STRING;
        private readonly string CONFIGURATION_CONNECTION_STRING = "Capwair.Test";

        [TestFixtureSetUp]
        public void TextFixtureSetup()
        {          
            // manually inject ORM into ctor...
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CONNECTION_STRING = ConfigurationManager.ConnectionStrings[CONFIGURATION_CONNECTION_STRING].ConnectionString;
            IORM iORM = new DapperAdapter(new SqlConnection(CONNECTION_STRING));
            _appRepository = new SqlServerRepository(iORM);

            _customersController       = new CustomerController(_appRepository);
            _customerAddressController = new CustomerAddresesController(_appRepository);
            _customerPhonesController  = new CustomerPhonesController(_appRepository);
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
            Assert.AreEqual(typeof(DapperAdapter), _appRepository.ORM);
        }

        [Description("End-to-end integration test")]
        [Category("LocalIntegration")]
        [Test, Explicit]
        public void CustomersRouteTest()
        {
            IEnumerable<dynamic> customers = _customersController.GetCustomers();
            Assert.IsNotNull(customers);
            Assert.Greater(customers.ToList().Count, 0);
        }

        [Description("End-to-end integration test")]
        [Category("LocalIntegration")]
        [Test, Explicit]
        public void AddressesRouteTest()
        {
            IEnumerable<dynamic> addresses = _customerAddressController.GetAddresses();
            Assert.IsNotNull(addresses);
            Assert.Greater(addresses.ToList().Count, 0);
        }

        [Description("End-to-end integration test")]
        [Category("LocalIntegration")]
        [Test, Explicit]
        public void PhoneNumbersRouteTest()
        {
            IEnumerable<dynamic> phoneNumbers = _customerPhonesController.GetPhoneNumbers();
            Assert.IsNotNull(phoneNumbers);
            Assert.Greater(phoneNumbers.ToList().Count, 0);
        }
    }
}
