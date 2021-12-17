using System;
using System.Collections.Generic;

namespace Ch19._2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteCompany root = new ConcreteCompany("北京总公司");
            root.Add(new HRDepartment("总公司人力资源部"));
            root.Add(new HRDepartment("总公司财务部"));
            ConcreteCompany comp = new ConcreteCompany("上海华东分公司");
            comp.Add(new HRDepartment("华东分公司人力资源部"));
            comp.Add(new FinanceDepartment("华东分公司财务部"));
            root.Add(comp);
            ConcreteCompany comp1 = new ConcreteCompany("杭州办事处");
            comp1.Add(new HRDepartment("南京办事处人力资源部"));
            comp1.Add(new FinanceDepartment("南京办事处财务部"));
            comp.Add(comp1);
            Console.WriteLine("结构图：");
            root.Display(1);
            Console.WriteLine("职责");
            root.LineOfDuty();
            Console.ReadKey();
        }
    }
    //公司类抽象接口
    abstract class Company
    {
        protected string name;
        public Company(string name)
        {
            this.name = name;
        }
        public abstract void Add(Company c);
        public abstract void Remove(Company c);
        public abstract void Display(int depth);
        public abstract void LineOfDuty();//履行职责
    }
    //具体公司
    class ConcreteCompany:Company
    {
        private List<Company> children = new List<Company>();
        public ConcreteCompany(string name) : base(name)
        {
        }
        public override void Add(Company c)
        {
            children.Add(c);
        }
        public override void Remove(Company c)
        {
            children.Remove(c);
        }
        public override void Display(int depth)
        {
            Console.WriteLine($"{new string('-',depth)}{name}");
            foreach (Company c in children)
            {
                c.Display(depth+1);
            }
        }
        public override void LineOfDuty()
        {
            foreach (Company c in children)
            {
                c.LineOfDuty();
            }
        }
    }
    //人力资源部门
    class HRDepartment:Company
    {
        public HRDepartment(string name) : base(name)
        {
        }
        public override void Add(Company c)
        {
        }
        public override void Remove(Company c)
        {
        }
        public override void Display(int depth)
        {
            Console.WriteLine($"{new string('-', depth)}{name}");
        }
        public override void LineOfDuty()
        {
            Console.WriteLine($"{name}员工招聘培训管理");
        }
    }
    //财务部门
    class FinanceDepartment:Company
    {
        public FinanceDepartment(string name) : base(name)
        {
        }
        public override void Add(Company c)
        {
        }
        public override void Remove(Company c)
        {
        }
        public override void Display(int depth)
        {
            Console.WriteLine($"{new string('-', depth)}{name}");
        }
        public override void LineOfDuty()
        {
            Console.WriteLine($"{name}公司财务收支管理");
        }
    }
}
