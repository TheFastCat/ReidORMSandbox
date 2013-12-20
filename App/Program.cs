using Ninject;
using SalesApplication.Data.Adapter.Contract;
using System.Collections.Generic;
using System.Diagnostics;

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

            IEnumerable<dynamic> customers    = iSalesAppData.GetAllCustomers();
            IEnumerable<dynamic> addresses    = iSalesAppData.GetAllAddresses();
            IEnumerable<dynamic> phoneNumbers = iSalesAppData.GetAllPhoneNumbers();
        }
    }
}
