using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISalesAppORM;
using Dapper;

namespace SalesAppORMDapperImpl
{
    public class SalesAppORMDapperImpl : ISalesAppORM.ISalesAppORM
    {
        private readonly string _connStr;

        public SalesAppORMDapperImpl(string connectionStr)
        {
            _connStr = connectionStr;
        }
    }
}
