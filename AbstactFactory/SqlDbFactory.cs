using System.Data.Common;
using System.Data.SqlClient;

namespace AbstactFactory
{
    public class SqlDbFactory : DbFactory
    {
        private static readonly string _connectionString = @"Server=SHAPC330\SQLEXPRESSHALTON;Database=StudentManageDB;Uid=sa;Pwd=Epdm2018";
        public override DbConnection CreateDbConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public override DbParameter CreateDbParameter(string parameterName, object value)
        {
            return new SqlParameter(parameterName, value);
        }
    }
}
