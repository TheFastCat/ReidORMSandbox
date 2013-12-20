﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SalesApplication.Data.ORM.Contract;
using System.Diagnostics;
using SalesApplication.Data.ORM;
using System.Data.SqlClient;
using System.Configuration;

namespace Test
{
    /// <summary>
    /// [TestFixture] for DapperAdapter
    /// </summary>
    [Category("LocalIntegration")]
    [TestFixture]
    public class MassiveAdapterTest
    {
        ISalesAppORM _iSalesAppORM;
        private string CONNECTION_STRING;
        private readonly string CONFIGURATION_CONNECTION_STRING = "Capwair.Test";

        [TestFixtureSetUp]
        public void TextFixtureSetup()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CONNECTION_STRING = ConfigurationManager.ConnectionStrings[CONFIGURATION_CONNECTION_STRING].ConnectionString;
            _iSalesAppORM = new MassiveAdapter(new SqlConnection(CONNECTION_STRING));
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
        public void MassiveIntegrationTest()
        {
            Assert.IsNotNull(_iSalesAppORM);
            Assert.IsInstanceOf<MassiveAdapter>(_iSalesAppORM);

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