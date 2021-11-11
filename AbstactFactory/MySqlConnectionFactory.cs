using System.Data.Common;
using MySql.Data.MySqlClient;

namespace AbstactFactory
{
    public class MySqlConnectionFactory:DbConnectionFactory//添加类的方式进行扩展，而不是在原来的代码上修改
    {
        private static readonly string _connectionString = @"....";
        public override DbConnection CreateDbConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
