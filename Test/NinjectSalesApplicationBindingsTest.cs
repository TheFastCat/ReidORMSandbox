using Ninject;
using Ninject.Modules;
using NUnit.Framework;
using SalesApplication.Data.Adapter.Contract;
using SalesApplication.Data.Adapter.Legacy.SQLServer;
using SalesApplication.Data.ORM;
using SalesApplication.Data.ORM.Contract;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Test
{
    /// <summary>
    /// [TestFixture] for verifying different NinjectModule binding configurations.
    /// </summary>
    [TestFixture]
    public class NinjectSalesApplicationBindingsTest
    {
        IKernel _kernel;

        abstract class ModuleBase : NinjectModule
        {
            protected readonly string CONNECTION_STRING;
            protected readonly string CONFIGURATION_CONNECTION_STRING = "Capwair.Test";

            protected ModuleBase()
            {
                //read required parameters from application configuration
                //these settings are required at runtime to retrieve Ninject type bindings for the application automatically
                //without them auto-binding will fail...
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                #region    Read Configuration Settings from App.Config
                CONNECTION_STRING = ConfigurationManager.ConnectionStrings[CONFIGURATION_CONNECTION_STRING].ConnectionString;
                #endregion Read Configuration Settings from App.Config

                #region    Error on Missing
                if (string.IsNullOrWhiteSpace(CONNECTION_STRING))
                {
                    string format = string.Format("Could not parse argument '{0}' value from Configuration AppSettings.",
                        CONFIGURATION_CONNECTION_STRING);
                    throw new ConfigurationErrorsException(format);
                }
                #endregion    Error on Missing
            }
        }

        class DapperModule : ModuleBase
        {
            public override void Load()
            {
                Bind<IDbConnection>().To<SqlConnection>().InSingletonScope().WithConstructorArgument("connectionString", CONNECTION_STRING);
                Bind<ISalesAppORM>().To<DapperAdapter>().InSingletonScope();
                Bind<ISalesAppData>().To<CapwairData>().InSingletonScope();
            }
        }

        class MassiveModule : ModuleBase
        {
            public override void Load()
            {
                Bind<IDbConnection>().To<SqlConnection>().InSingletonScope().WithConstructorArgument("connectionString", CONNECTION_STRING);
                Bind<ISalesAppORM>().To<MassiveAdapter>().InSingletonScope();
                Bind<ISalesAppData>().To<CapwairData>().InSingletonScope();
            }
        }

        [TestFixtureSetUp]
        public void TextFixtureSetup()
        {     
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {

        }

        [SetUp]
        public void SetUp()
        {
            _kernel = new StandardKernel();    
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Description("Verifies a NinjectModule configured for CapwairData and Dapper ORM loads types as expected at runtime")]
        [Test]
        public void NinjectCapwairDataAndDapperCompositionTest()
        {
            _kernel.Load(new DapperModule());

            IDbConnection idbConnection = _kernel.TryGet<IDbConnection>();
                Assert.IsNotNull(idbConnection);
                Assert.IsInstanceOf<SqlConnection>(idbConnection);
                Assert.IsNotNullOrEmpty(idbConnection.ConnectionString);
                Assert.AreEqual(ConnectionState.Closed, idbConnection.State);

            ISalesAppData iSalesAppData = _kernel.TryGet<ISalesAppData>();
                Assert.IsNotNull(iSalesAppData);
                Assert.IsInstanceOf<CapwairData>(iSalesAppData);

            Assert.IsNotNull(iSalesAppData.ORM);
                Assert.AreEqual(typeof(DapperAdapter), iSalesAppData.ORM);
        }

        [Description("Verifies a NinjectModule configured for CapwairData and Massive ORM loads types as expected at runtime")]
        [Test]
        public void NinjectCapwairDataAndMassiveCompositionTest()
        {
            _kernel.Load(new MassiveModule());

            IDbConnection idbConnection = _kernel.TryGet<IDbConnection>();
                Assert.IsNotNull(idbConnection);
                Assert.IsInstanceOf<SqlConnection>(idbConnection);
                Assert.IsNotNullOrEmpty(idbConnection.ConnectionString);
                Assert.AreEqual(ConnectionState.Closed, idbConnection.State);

            ISalesAppData iSalesAppData = _kernel.TryGet<ISalesAppData>();
                Assert.IsNotNull(iSalesAppData);
                Assert.IsInstanceOf<CapwairData>(iSalesAppData);

                Assert.IsNotNull(iSalesAppData.ORM);
                Assert.AreEqual(typeof(MassiveAdapter), iSalesAppData.ORM);
        }

        [Description("Verifies a NinjectModule configured for CapwairData and Dapper GetAllAddresses() from configured conn str as expected")]
        [Category("LocalIntegration")]
        [Test,Explicit]
        public void NinjectCapwairDataAndDapperGetAllAddressesTest()
        {
            _kernel.Load(new DapperModule());
            ISalesAppData iSalesAppData = _kernel.TryGet<ISalesAppData>();
            IEnumerable<dynamic> addresses    = iSalesAppData.GetAllAddresses();
                Assert.IsNotNull(addresses);
                Assert.Greater(addresses.ToList().Count,0);
        }

        [Description("Verifies a NinjectModule configured for CapwairData and Dapper GetAllCustomers() from configured conn str as expected")]
        [Category("LocalIntegration")]
        [Test, Explicit]
        public void NinjectCapwairDataAndDapperGetAllCustomersTest()
        {
            _kernel.Load(new DapperModule());
            ISalesAppData iSalesAppData = _kernel.TryGet<ISalesAppData>();
            IEnumerable<dynamic> addresses = iSalesAppData.GetAllAddresses();
                Assert.IsNotNull(addresses);
                Assert.Greater(addresses.ToList().Count, 0);
        }

        [Description("Verifies a NinjectModule configured for CapwairData and Dapper GetAllCustomers() from configured conn str as expected")]
        [Category("LocalIntegration")]
        [Test, Explicit]
        public void NinjectCapwairDataAndDapperGetAllPhoneNumbersTest()
        {
            _kernel.Load(new DapperModule());
            ISalesAppData iSalesAppData = _kernel.TryGet<ISalesAppData>();
            IEnumerable<dynamic> phoneNumbers = iSalesAppData.GetAllPhoneNumbers();
                Assert.IsNotNull(phoneNumbers);
                Assert.Greater(phoneNumbers.ToList().Count, 0);
        }

        [Description("Verifies a NinjectModule configured for CapwairData and Massive GetAllAddresses() from configured conn str as expected")]
        [Category("LocalIntegration")]
        [Test, Explicit]
        public void NinjectCapwairDataAndMassiveGetAllAddressesTest()
        {
            _kernel.Load(new MassiveModule());
            ISalesAppData iSalesAppData = _kernel.TryGet<ISalesAppData>();
            IEnumerable<dynamic> addresses = iSalesAppData.GetAllAddresses();
                Assert.IsNotNull(addresses);
                Assert.Greater(addresses.ToList().Count, 0);
        }

        [Description("Verifies a NinjectModule configured for CapwairData and Massive GetAllCustomers() from configured conn str as expected")]
        [Category("LocalIntegration")]
        [Test, Explicit]
        public void NinjectCapwairDataAndMassiveGetAllCustomersTest()
        {
            _kernel.Load(new MassiveModule());
            ISalesAppData iSalesAppData = _kernel.TryGet<ISalesAppData>();
            IEnumerable<dynamic> addresses = iSalesAppData.GetAllAddresses();
                Assert.IsNotNull(addresses);
                Assert.Greater(addresses.ToList().Count, 0);
        }

        [Description("Verifies a NinjectModule configured for CapwairData and Massive GetAllCustomers() from configured conn str as expected")]
        [Category("LocalIntegration")]
        [Test, Explicit]
        public void NinjectCapwairDataAndMassiveGetAllPhoneNumbersTest()
        {
            _kernel.Load(new MassiveModule());
            ISalesAppData iSalesAppData = _kernel.TryGet<ISalesAppData>();
            IEnumerable<dynamic> phoneNumbers = iSalesAppData.GetAllPhoneNumbers();
                Assert.IsNotNull(phoneNumbers);
                Assert.Greater(phoneNumbers.ToList().Count, 0);
        }
    }
}
