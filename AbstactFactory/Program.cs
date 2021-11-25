using System;
using System.Data.Common;

namespace AbstactFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //DbConnectionFactory sqlConnectionFactory = new SqlConnectionFactory();
            //DbParameterFactory sqlParameterFactory = new SqlParameterFactory();
            //SqlHelper sqlHelper = new SqlHelper(sqlConnectionFactory, sqlParameterFactory);//为了让自己稳定,一层一层的往外甩锅

            DbFactory dbFactory = new SqlDbFactory();
            SqlHelper sqlHelper = new SqlHelper(dbFactory);
            int age = 30;
            string selectSql = "select count(*) from Students where Age>@Age";
            object count = sqlHelper.ExecuteScalar(selectSql,new DbParameter[]{ sqlHelper.CreateDbParameter("@Age",age)});
            Console.WriteLine($"共有{count}条记录");
            Console.ReadKey();
        }
    }
}
