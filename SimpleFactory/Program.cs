using System;

namespace SimpleFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            //SqlHelper sqlHelper = new SqlHelper();
            SqlHelper sqlHelper = new SqlHelper(new SqlConnectionFactory());//为了让自己稳定,一层一层的往外甩锅

            string selectSql = "select count(*) from Students";
            object count = sqlHelper.ExecuteScalar(selectSql);
            Console.WriteLine($"共有{count}条记录");
            Console.ReadKey();
        }
    }
}
