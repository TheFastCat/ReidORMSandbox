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
