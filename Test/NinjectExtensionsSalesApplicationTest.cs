using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ninject;
using ISalesAppORM;
using System.Diagnostics;
using SalesAppORMDapperImpl;

namespace Test
{
    /// <summary>
    /// [TestFixture] for Ninject.Extensions.SalesApplication bindings.
    /// </summary>
    [TestFixture]
    public class NinjectExtensionsSalesApplicationTest
    {
        IKernel _kernel;
        ISalesAppORM.ISalesAppORM _iSalesAppORM;

        [TestFixtureSetUp]
        public void TextFixtureSetup()
        {
            Debugger.Launch();
             _kernel = new StandardKernel();         
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
        public void DapperBindingTest()
        {
            _iSalesAppORM = _kernel.TryGet<ISalesAppORM.ISalesAppORM>();
            Assert.IsInstanceOf<SalesAppORMDapperImpl.SalesAppORMDapperImpl>(_iSalesAppORM);
        }
    }
}
