using System;

namespace Ch15._2
{
    //工厂方法访问数据路
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            //现在如果要换数据库，只需要把newSqlServerFactory()改成new AccessFactory()，
            //此时由于多态的关系，使得声明IUser接口的对象iu事先根本不知道是在访问哪个数据库，
            //却可以在运行时很好地完成工作，这就是所谓的业务逻辑与数据访问的解耦。
            IFactory factory = new SqlServerFactory();
            IUser iu = factory.CreateUser();
            iu.Insert(user);
            iu.GetUser(1);
            Console.ReadKey();
        }
    }
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    interface IUser
    {
        void Insert(User user);
        User GetUser(int id);
    }
    //SQL Server数据库
    class SqlServerUser:IUser
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
    //Access
    class AccessUser : IUser
    {
        public void Insert(User user)
        {
            Console.WriteLine("在Access中给User表增加一条记录");
        }
        public User GetUser(int id)
        {
            Console.WriteLine($"在Access中根据编号为{id}得到User表一条记录");
            return null;
        }
    }
    interface IFactory
    {
        IUser CreateUser();
    }
    class SqlServerFactory:IFactory
    {
        public IUser CreateUser()
        {
            return new SqlServerUser();
        }
    }
    class AccessFactory : IFactory
    {
        public IUser CreateUser()
        {
            return new AccessUser();
        }
    }
}
