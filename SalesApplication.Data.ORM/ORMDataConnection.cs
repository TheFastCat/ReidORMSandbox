using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApplication.Data.ORM.Contract;
using SalesApplication.Data.Contract;
using SalesApplication.Data.Model;

namespace SalesApplication.Data.ORM
{
    public abstract class ORMDataConnection : IDataConnection
    {
        private readonly string _connStr;

        public ORMDataConnection(string connectionStr)
        {
            _connStr = connectionStr;
        }

        public string ConnectionString
        {
            get { return _connStr; }
        }
    }
}
