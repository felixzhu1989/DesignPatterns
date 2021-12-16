using System;

namespace Ch09._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Resume a = new Resume("大鸟");
            a.SetPersonalInfo("男", "29");
            a.SetWorkExperience("1998-2000", "xxx公司");
            Resume b = a.Clone() as Resume;
            b.SetWorkExperience("2000-2006","yyy公司");
            //我们期望的是两份简历的工作经历不一样
            //但是非常遗憾，修改引用对象，导致原来的对象也被修改，这就是浅拷贝原因
            a.Display();
            b.Display();
            Console.ReadKey();
        }
    }
    #region 简历类继承ICloneable接口
    class Resume :ICloneable
    {
        private string name;
        private string gender;
        private string age;
        private WorkExperience work;//引用工作经理对象
        //private string timeArea;
        //private string company;
        public Resume(string name)
        {
            this.name = name;
            work = new WorkExperience();//实例化建立时同时实例化工作经验
        }
        //设置个人信息
        public void SetPersonalInfo(string gender, string age)
        {
            this.gender = gender;
            this.age = age;
        }
        //设置工作经历(改成引用类型)
        public void SetWorkExperience(string timeArea, string company)
        {
            work.TimeArea = timeArea;
            work.Company = company;
        }
        //显示
        public void Display()
        {
            Console.WriteLine($"{name} {gender} {age}");
            Console.WriteLine($"工作经验：{work.TimeArea} {work.Company}");
        }
        //实现接口的方法，用来克隆对象（浅拷贝）
        public object Clone()
        {
            return (object)this.MemberwiseClone();
        }
    }
    #endregion
    //工作经历
    class WorkExperience
    {
        public string TimeArea { get; set; }
        public string Company { get; set; }
    }
}
