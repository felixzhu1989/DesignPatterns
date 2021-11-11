using System.Data.Common;
using System.Data.SqlClient;

namespace AbstactFactory
{
    public class SqlConnectionFactory:DbConnectionFactory
    {
        private static readonly string _connectionString = @"Server=SHAPC330\SQLEXPRESSHALTON;Database=StudentManageDB;Uid=sa;Pwd=Epdm2018";
        public override DbConnection CreateDbConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
