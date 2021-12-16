using System;

namespace Ch15._3
{
    //抽象工厂模式的数据访问程序
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User();
            Department dept = new Department();
            //IFactory factory = new SqlServerFactory();
            IFactory factory = new AccessFactory();
            IUser iu = factory.CreateUser();
            iu.Insert(user);
            iu.GetUser(1);
            //与具体的数据库访问解除了依赖
            IDepartment iDept = factory.CreateDepartment();
            iDept.Insert(dept);
            iDept.GetDepartment(1);
            Console.ReadKey();
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
    interface IFactory
    {
        IUser CreateUser();
        IDepartment CreateDepartment();
    }
    class SqlServerFactory : IFactory
    {
        public IUser CreateUser()
        {
            return new SqlServerUser();
        }
        public IDepartment CreateDepartment()
        {
            return new SqlServerDepartment();
        }
    }
    class AccessFactory : IFactory
    {
        public IUser CreateUser()
        {
            return new AccessUser();
        }
        public IDepartment CreateDepartment()
        {
            return new AccessDepartment();
        }
    }
}
