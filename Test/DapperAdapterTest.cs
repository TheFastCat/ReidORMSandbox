using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SalesApplication.Data.ORM.Contract;
using System.Diagnostics;
using SalesApplication.Data.ORM;

namespace Test
{
    /// <summary>
    /// [TestFixture] for SalesAppORMDapperImpl
    /// </summary>
    [TestFixture]
    public class DapperAdapterTest
    {
        ISalesAppORM _iSalesAppORM;

        [TestFixtureSetUp]
        public void TextFixtureSetup()
        {
            _iSalesAppORM = new DapperAdapter("Data Source=svclosq51;Initial Catalog=CapwairDB;Persist Security Info=True;User ID=aura;Password=lauraaura");
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
        public void SimpleTest()
        {
            Assert.IsNotNull(_iSalesAppORM);
            Assert.IsInstanceOf<DapperAdapter>(_iSalesAppORM);
        }
    }
}
