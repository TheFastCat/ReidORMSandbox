using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;
using SalesApplication.Data.ORM;
using SalesApplication.Data.ORM.Contract;
using SalesApplication.Data.Adapter.Contract;
using SalesApplication.Data.Adapter.Legacy.SQLServer;
using System.Data.SqlClient;
using SalesApplication.Data.Model;

namespace Test
{
    /// <summary>
    /// [TestFixture] for SalesAppORMDapperImpl
    /// </summary>
    [TestFixture]
    public class CapwairDataTest
    {
        ISalesAppData _salesAppData;

        [TestFixtureSetUp]
        public void TextFixtureSetup()
        {
            // manually inject ORM into ctor...
            ISalesAppORM iSalesAppORM = new DapperAdapter(new SqlConnection("Data Source=svclosq51;Initial Catalog=CapwairDB;Persist Security Info=True;User ID=aura;Password=lauraaura"));
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
            Assert.AreEqual(typeof(DapperAdapter), _salesAppData.ORM);
        }

        [Description("End-to-end integration test")]
        [Category("LocalIntegration")]
        [Test, Explicit]
        public void IntegrationTest()
        {
            IList<Customer> customers = _salesAppData.GetAllCustomers();
            Assert.IsNotNull(customers);
            Assert.Greater(customers.Count, 0);

            IList<Address> addresses = _salesAppData.GetAllAddresses();
            Assert.IsNotNull(addresses);
            Assert.Greater(addresses.Count, 0);

            IList<PhoneNumber> phoneNumbers = _salesAppData.GetAllPhoneNumbers();
            Assert.IsNotNull(phoneNumbers);
            Assert.Greater(phoneNumbers.Count, 0);
        }
    }
}
