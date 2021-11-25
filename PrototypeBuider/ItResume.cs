using System;

namespace PrototypeBuilder
{
   public class ItResume:ResumeBase
    {
        public WorkExperience WorkExperience { get; set; }
        public override void Display()
        {
            Console.WriteLine($"姓名：\t{this.Name}");
            Console.WriteLine($"性别：\t{this.Gender}");
            Console.WriteLine($"年龄：\t{this.Age}");
            Console.WriteLine($"期望薪资：\t{this.ExpectedSalary}");
            Console.WriteLine("--------------------------------");
            if (this.WorkExperience!=null)
            {
                this.WorkExperience.Display();
            }
        }
    }
}
