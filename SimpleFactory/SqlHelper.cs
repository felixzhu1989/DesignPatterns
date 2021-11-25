using System.Data.Common;

namespace SimpleFactory
{
    public class SqlHelper
    {
        private DbConnectionFactory _connectionFactory;//聚合到SqlHelper中

        public SqlHelper(DbConnectionFactory connectionFactory)//通过构造函数传参进来
        {
            this._connectionFactory = connectionFactory;
        }
        /// <summary>
        /// 增删改，返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql)
        {
            //使用基类接收,适用于其他类型的数据库
            using (DbConnection conn = _connectionFactory.CreateDbConnection())
            {
                using (DbCommand cmd =conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 查询操作，返回查询结果中的第一行第一列的值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql)
        {
            using (DbConnection conn = _connectionFactory.CreateDbConnection())
            {
                using (DbCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
