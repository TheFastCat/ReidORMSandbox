using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using SalesApplication.Data.Adapter.Contract;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel();
            ISalesAppData iSalesAppData = ninjectKernel.TryGet<ISalesAppData>();
        }
    }
}
