using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SalesApplication.Data.ORM.Contract;
using System.Diagnostics;
using SalesApplication.Data.ORM;
using SalesApplication.Data.Model;
using System.Data.SqlClient;

namespace Test
{
    /// <summary>
    /// [TestFixture] for DapperAdapter
    /// </summary>
    [Category("LocalIntegration")]
    [TestFixture]
    public class DapperAdapterTest
    {
        ISalesAppORM _iSalesAppORM;

        [TestFixtureSetUp]
        public void TextFixtureSetup()
        {
            _iSalesAppORM = new DapperAdapter(new SqlConnection("Data Source=svclosq51;Initial Catalog=CapwairDB;Persist Security Info=True;User ID=aura;Password=lauraaura"));
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
        public void IntegrationTest()
        {
            Assert.IsNotNull(_iSalesAppORM);
            Assert.IsInstanceOf<DapperAdapter>(_iSalesAppORM);

            IList<Customer> customers = _iSalesAppORM.GetCustomersFromSP("ObjCustomer");
            Assert.IsNotNull(customers);
            Assert.Greater(customers.Count, 0);

            IList<Address> addresses = _iSalesAppORM.GetCustomerAddressesFromSP("ObjCustomerAddresses");
            Assert.IsNotNull(addresses);
            Assert.Greater(addresses.Count, 0);

            IList<PhoneNumber> phoneNumbers = _iSalesAppORM.GetCustomerPhoneNumbersFromSP("ObjCustomerPhones");
            Assert.IsNotNull(phoneNumbers);
            Assert.Greater(phoneNumbers.Count, 0);
        }
    }
}
