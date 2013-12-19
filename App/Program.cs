using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using SalesApplication.Data.Adapter.Contract;
using SalesApplication.Data.Model;
using System.Diagnostics;

namespace App
{
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
