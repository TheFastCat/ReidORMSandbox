using Ninject.Modules;
using Data.Adapter.Contract;
using Data.Adapter.Legacy.SQLServer;
using Data.ORM;
using Data.ORM.Contract;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Ninject.Extensions.Api
{
    /// <summary>
    /// This class defines the DI/IoC runtime type bindings for Ninject to use for the SalesApplication
    /// </summary>
    public class ApiNinjectModule : NinjectModule
    {
        private readonly string CONNECTION_STRING;
        private readonly string CONFIGURATION_CONNECTION_STRING = "Capwair.Test";

        public ApiNinjectModule()
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

        /// <summary>
        /// Contains type bindings for the SalesApplication
        /// </summary>
        public override void Load()
        {
            Bind<IDbConnection>().To<SqlConnection>().InSingletonScope().WithConstructorArgument("connectionString", CONNECTION_STRING);
            Bind<IORM>().To<DapperAdapter>().InSingletonScope();
            //Bind<IORM>().To<MassiveAdapter>().InSingletonScope();
            Bind<IRepository>().To<SqlServerRepository>().InSingletonScope();
        }
    }
}
