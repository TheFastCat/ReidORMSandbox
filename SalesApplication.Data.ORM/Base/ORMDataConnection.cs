﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesApplication.Data.ORM.Contract;
using System.Data;

namespace SalesApplication.Data.ORM.Base
{
    public abstract class ORMDataConnection
    {
        private readonly IDbConnection _dbConnection;

        public ORMDataConnection(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        protected IDbConnection DbConnection
        {
            get { return _dbConnection; }
        }
    }
}