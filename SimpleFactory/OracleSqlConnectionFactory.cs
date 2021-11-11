using System.Data.Common;

namespace SimpleFactory
{
    class OracleSqlConnectionFactory:DbConnectionFactory
    {
        private static readonly string _connectionString = @"....";
        public override DbConnection CreateDbConnection()
        {
            return null;
        }
    }
}
