using System.Data.Common;

namespace AbstactFactory
{
    public class SqlHelper
    {
        #region 连接与参数分离
        //private DbConnectionFactory _connectionFactory;//聚合到SqlHelper中
        //private DbParameterFactory _parameterFactory;
        //public SqlHelper(DbConnectionFactory connectionFactory, DbParameterFactory parameterFactory)//通过构造函数传参进来
        //{
        //    this._connectionFactory = connectionFactory;
        //    this._parameterFactory = parameterFactory;
        //}
        //public DbParameter CreateDbParameter(string parameterName, object value)
        //{
        //    return _parameterFactory.CreateDbParameter(parameterName, value);
        //} 
        #endregion

        private DbFactory _dbFactory;
        public SqlHelper(DbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
        }
        public DbParameter CreateDbParameter(string parameterName, object value)
        {
            return _dbFactory.CreateDbParameter(parameterName, value);
        }

        /// <summary>
        /// 增删改，返回受影响的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string sql,params DbParameter[] parms)//参数也是基类的
        {
            //使用基类接收,适用于其他类型的数据库
            using (DbConnection conn = _dbFactory.CreateDbConnection())
            {
                using (DbCommand cmd =conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    if (parms != null)
                    {
                        cmd.Parameters.AddRange(parms);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// 查询操作，返回查询结果中的第一行第一列的值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExecuteScalar(string sql, params DbParameter[] parms)
        {
            using (DbConnection conn = _dbFactory.CreateDbConnection())
            {
                using (DbCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = sql;
                    if (parms != null)
                    {
                        cmd.Parameters.AddRange(parms);
                    }
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
