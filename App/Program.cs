using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISalesAppORM;
using Ninject;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel();
            ISalesAppORM.ISalesAppORM iSalesAppORM = ninjectKernel.TryGet<ISalesAppORM.ISalesAppORM>();
        }
    }
}
