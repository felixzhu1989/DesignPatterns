using System;

namespace Ch15._1
{   //基本数据库访问
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            SqlServerUser userService = new SqlServerUser();
            userService.Insert(user);
            userService.GetUser(1);
            Console.ReadKey();
        }
        //这里之所以不能换数据库，
        //原因就在于SqlserverUser su =new SqlserverUser()使得su这个对象
        //被框死在SQL Server上了。
    }
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class SqlServerUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在SQL Server中给User表增加一条记录");
        }
        public User GetUser(int id)
        {
            Console.WriteLine($"在SQL Server中根据编号为{id}得到User表一条记录");
            return null;
        }
    }
}
