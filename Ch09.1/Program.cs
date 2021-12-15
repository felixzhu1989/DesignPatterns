using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch09._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //复制三分建立，代码重复
            Resume a = new Resume("大鸟");
            a.SetPersonalInfo("男","29");
            a.SetWorkExperience("1998-2000","xxx公司");
            /*
            Resume b = new Resume("大鸟");
            b.SetPersonalInfo("男", "29");
            b.SetWorkExperience("1998-2000", "xxx公司");
            Resume c = new Resume("大鸟");
            c.SetPersonalInfo("男", "29");
            c.SetWorkExperience("1998-2000", "xxx公司");
            */
            Resume b = a;
            Resume c = a;
            a.Display();
            b.Display();
            c.Display();
            Console.ReadKey();
        }
    }

    class Resume
    {
        private string name;
        private string gender;
        private string age;
        private string timeArea;
        private string company;
        public Resume(string name)
        {
            this.name = name;
        }
        //设置个人信息
        public void SetPersonalInfo(string gender, string age)
        {
            this.gender = gender;
            this.age = age;
        }
        //设置工作经历
        public void SetWorkExperience(string timeArea, string company)
        {
            this.timeArea = timeArea;
            this.company = company;
        }
        //显示
        public void Display()
        {
            Console.WriteLine($"{name} {gender} {age}");
            Console.WriteLine($"工作经验：{timeArea} {company}");
        }
    }
}
