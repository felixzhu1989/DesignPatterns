using System;
using System.Reflection;
using System.Configuration;

namespace Ch15._4
{
    //用简单工厂来改进抽象工厂
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            Department dept = new Department();
            //直接得到实际的数据库访问实例，而不存在任何依赖
            //客户端没有出现任何一个SQL Server或Access的字样，达到了解耦的目的。
            IUser iu = DataAccess.CreateUser();
            iu.Insert(user);
            iu.GetUser(1);
            //与具体的数据库访问解除了依赖
            IDepartment iDept = DataAccess.CreateDepartment();
            iDept.Insert(dept);
            iDept.GetDepartment(1);
            Console.ReadKey();
        }
    }
    class DataAccess
    {
        private static readonly string AssemblyName = "Ch15.4";//右键项目属性查看程序集
        //读取配置文件,获取数据库配置
        private static readonly string db = ConfigurationManager.AppSettings["DB"];
        //private static readonly string db = "SqlServer";
        //private static readonly string db = "Access";
        //DataAccess类，用反射技术，取代IFactory、SqlserverFactory和AccessFactory。
        public static IUser CreateUser()
        {
            string className = $"{AssemblyName}.{db}User";//类的完全限定名
            return (IUser)Assembly.Load(AssemblyName).CreateInstance(className);
            /*
            IUser result = null;
            switch (db)
            {
                case "SqlServer":
                    result = new SqlServerUser();
                    break;
                case "Access":
                    result = new AccessUser();
                    break;
            }
            return result;
            */
        }
        public static IDepartment CreateDepartment()
        {
            string className = $"{AssemblyName}.{db}Department";//类的完全限定名
            return (IDepartment)Assembly.Load(AssemblyName).CreateInstance(className);
            /*
            IDepartment result = null;
            switch (db)
            {
                case "SqlServer":
                    result = new SqlServerDepartment();
                    break;
                case "Access":
                    result = new AccessDepartment();
                    break;
            }            
            return result;
            */
        }
    }
    class Department
    {
        public int Id { get; set; }
        public string DeptName { get; set; }
    }
    interface IDepartment
    {
        void Insert(Department department);
        Department GetDepartment(int id);
    }
    class SqlServerDepartment : IDepartment
    {
        public void Insert(Department department)
        {
            Console.WriteLine("在SQL Server中给Department表增加一条记录");
        }
        public Department GetDepartment(int id)
        {
            Console.WriteLine($"在SQL Server中根据编号为{id}得到Department表一条记录");
            return null;
        }
    }
    class AccessDepartment : IDepartment
    {
        public void Insert(Department department)
        {
            Console.WriteLine("在Access中给Department表增加一条记录");
        }
        public Department GetDepartment(int id)
        {
            Console.WriteLine($"在Access中根据编号为{id}得到Department表一条记录");
            return null;
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
    class SqlServerUser : IUser
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
}
