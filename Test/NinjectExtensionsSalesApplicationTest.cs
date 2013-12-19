using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Ninject;
using System.Diagnostics;
using SalesApplication.Data.ORM;
using SalesApplication.Data.ORM.Contract;
using SalesApplication.Data.Adapter.Contract;
using SalesApplication.Data.Adapter.Legacy.SQLServer;
using System.Data;
using System.Data.SqlClient;

namespace Test
{
    /// <summary>
    /// [TestFixture] for Ninject.Extensions.SalesApplication bindings.
    /// </summary>
    [TestFixture]
    public class NinjectExtensionsSalesApplicationTest
    {
        IKernel _kernel;
        ISalesAppData _iSalesAppData;
        IDbConnection _idbConnection;

        [TestFixtureSetUp]
        public void TextFixtureSetup()
        {
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
        }

        [Description("Verifies Ninject.Extensions.SalesApplication.Api's bindings are as expected")]
        [Test]
        public void NinjectCompositionTest()
        {
            _idbConnection = _kernel.TryGet<IDbConnection>();
            Assert.IsNotNull(_idbConnection);
            Assert.IsInstanceOf<SqlConnection>(_idbConnection);
            Assert.IsNotNullOrEmpty(_idbConnection.ConnectionString);
            Assert.AreEqual(ConnectionState.Closed, _idbConnection.State);

            _iSalesAppData = _kernel.TryGet<ISalesAppData>();
            Assert.IsNotNull(_iSalesAppData);
            Assert.IsInstanceOf<CapwairData>(_iSalesAppData);

            // verify that the impl of the ORM is what we expect
            //Assert.AreEqual(typeof(DapperAdapter), _iSalesAppData.ORM);
            Assert.AreEqual(typeof(MassiveAdapter), _iSalesAppData.ORM);
        }
    }
}
