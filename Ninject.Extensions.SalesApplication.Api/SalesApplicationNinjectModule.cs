using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Ninject.Modules;
using Ninject.Syntax;
using System.Configuration;
using SalesApplication.Data.ORM;
using SalesApplication.Data.ORM.Contract;
using SalesApplication.Data.Adapter.Contract;
using SalesApplication.Data.Adapter.Legacy.SQLServer;
using System.Data;
using System.Data.SqlClient;

namespace Ninject.Extensions.SalesApplication
{
    /// <summary>
    /// This class defines the DI/IoC runtime type bindings for Ninject to use for the SalesApplication
    /// </summary>
    public class SalesApplicationNinjectModule : NinjectModule
    {
        private readonly string CONNECTION_STRING;
        private readonly string YOUR_VALUE_HERE = "YOUR_VALUE_HERE";

        private readonly string CONFIGURATION_CONNECTION_STRING = "SalesApplication:NinjectBindings:DBConnStr";

        public SalesApplicationNinjectModule()
        {
            //read required parameters from application configuration
            //these settings are required at runtime to retrieve Ninject type bindings for the application automatically
            //without them auto-binding will fail...
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            #region    Create Missing Configuration Stubs if Missing
            if (!ConfigurationManager.AppSettings.AllKeys.Contains(CONFIGURATION_CONNECTION_STRING))
            {
                config.AppSettings.Settings.Add(CONFIGURATION_CONNECTION_STRING, YOUR_VALUE_HERE);
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("AppSettings");
            }
            #endregion Create Missing Configuration Stubs if Missing

            #region    Read Configuration Settings from App.Config
            CONNECTION_STRING = ConfigurationManager.AppSettings[CONFIGURATION_CONNECTION_STRING];
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
            Bind<ISalesAppORM>().To<DapperAdapter>().InSingletonScope();
            Bind<ISalesAppData>().To<CapwairData>().InSingletonScope();
        }
    }
}
