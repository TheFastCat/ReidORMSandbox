using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ISalesAppORM;
using System.Diagnostics;
using SalesAppORMDapperImpl;

namespace Test
{
    /// <summary>
    /// [TestFixture] for SalesAppORMDapperImpl
    /// </summary>
    [TestFixture]
    public class SalesAppORMDapperImplTest
    {
        ISalesAppORM.ISalesAppORM _iSalesAppORM;

        [TestFixtureSetUp]
        public void TextFixtureSetup()
        {
            _iSalesAppORM = new SalesAppORMDapperImpl.SalesAppORMDapperImpl("Data Source=svclosq51;Initial Catalog=CapwairDB;Persist Security Info=True;User ID=aura;Password=lauraaura");
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
            _iSalesAppORM = null;
        }

        [Test]
        public void SalesAppORMDapperImplTest()
        {
            
        }
    }
}
