using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApplication.Data.Contract
{
    public interface IDataConnection
    {
        string ConnectionString { get; }
    }
}
