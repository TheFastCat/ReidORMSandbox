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

namespace Test
{
    /// <summary>
    /// [TestFixture] for SalesAppORMDapperImpl
    /// </summary>
    [TestFixture]
    public class CapwairDataTest
    {
        ISalesAppData _salesAppRepo;

        [TestFixtureSetUp]
        public void TextFixtureSetup()
        {
            // manually inject ORM into ctor...
            ISalesAppORM iSalesAppORM = new DapperAdapter("Data Source=svclosq51;Initial Catalog=CapwairDB;Persist Security Info=True;User ID=aura;Password=lauraaura");
            _salesAppRepo = new CapwairData(iSalesAppORM);
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
            Assert.IsNotNull(_salesAppRepo);
            Assert.IsInstanceOf<CapwairData>(_salesAppRepo);
            Assert.AreEqual(typeof(DapperAdapter), _salesAppRepo.ORM);
        }
    }
}
