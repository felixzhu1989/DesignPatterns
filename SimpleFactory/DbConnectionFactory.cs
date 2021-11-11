using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SimpleFactory
{
    #region 简单工厂模式，几乎违反了所有的设计原则，将创建连接数据库类（变化的）隔离到简单工厂类中，为适应连接不同的数据库
    //public static class DbConnectionFactory
    //{
    //    private static readonly string _connectionString = @"Server=SHAPC330\SQLEXPRESSHALTON;Database=StudentManageDB;Uid=sa;Pwd=Epdm2018";
    //    private static readonly string _dbType = "SqlServer";//正确的做法是放在配置文件中
    //    public static DbConnection CreateDbConnection()
    //    {
    //        if (_dbType == "SqlServer")//也可以通过反射
    //        {
    //            return new SqlConnection(_connectionString);
    //        }
    //        else if (_dbType == "MySql")
    //        {
    //            return new MySqlConnection(_connectionString);
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }
    //}
    #endregion

    #region 工厂方法，对简单工厂的改进，面向抽象编程，抽象类
    public abstract class DbConnectionFactory
    {
        public abstract DbConnection CreateDbConnection();
    } 
    #endregion


}
