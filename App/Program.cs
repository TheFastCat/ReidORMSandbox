using Ninject;
using SalesApplication.Data.Adapter.Contract;
using System.Collections.Generic;
using System.Diagnostics;
using System;
using System.Linq;
using SalesApplication.Data.ORM;// normally the impl assemblies would not be referenced by the application code; however we use this little console app for testing verification
using SalesApplication.Data.ORM.Contract; // (<^) [this referenced also required since we are cheating]

namespace App
{
    /// <summary>
    /// This is a dummy console application useful for setting DEBUG breakpoints and stepping through application runtime execution.
    /// Ninject runtime type bindings are loaded automatically from Ninject.Extensions.SalesApplication.Api (because there is a reference
    /// to it in this .csproj's 'references'). Altering bindings in Ninject.Extensions.SalesApplication.Api will change the runtime types
    /// loaded in this application.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Debugger.Launch();

            IKernel ninjectKernel = new StandardKernel();
            ISalesAppData iSalesAppData = ninjectKernel.TryGet<ISalesAppData>();

            // this check wouldn't happen in a real consuming application because it would never have reference to the bound runtime type implementation class (or assembly)
            // for the interface; however we cheat in order to peek inside to see what implementation classes Ninject is actually loading at runtime
            if(iSalesAppData.ORM != typeof(DapperAdapter))
                throw new TypeLoadException("Wrong ORM Adapter loaded from Ninject. Verify Ninject.Extensions.SalesApplication.Api binding configuration");

            IEnumerable<dynamic> customers    = iSalesAppData.GetAllCustomers();
            IEnumerable<dynamic> addresses    = iSalesAppData.GetAllAddresses();
            IEnumerable<dynamic> phoneNumbers = iSalesAppData.GetAllPhoneNumbers();

            if (customers.ToList().Count == 0)
                throw new ApplicationException("No customers returned");

            if (addresses.ToList().Count == 0)
                throw new ApplicationException("No addresses returned");

            if (phoneNumbers.ToList().Count == 0)
                throw new ApplicationException("No phone numbers returned");
        }
    }
}
