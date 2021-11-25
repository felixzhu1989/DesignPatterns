using System;

namespace PrototypeBuilderClone
{
    public class ItResume : ResumeBase
    {
        public WorkExperience WorkExperience { get; set; }
        public override void Display()
        {
            Console.WriteLine($"姓名：\t{this.Name}");
            Console.WriteLine($"性别：\t{this.Gender}");
            Console.WriteLine($"年龄：\t{this.Age}");
            Console.WriteLine($"期望薪资：\t{this.ExpectedSalary}");
            Console.WriteLine("--------------------------------");
            if (this.WorkExperience != null)
            {
                this.WorkExperience.Display();
            }
        }
        //改进成克隆方法
        public override ResumeBase Clone()
        {
            //ItResume resume = new ItResume()
            //{
            //    Name = this.Name,
            //    Gender = this.Gender,
            //    Age = this.Age,
            //    ExpectedSalary = this.ExpectedSalary,
            //    WorkExperience = new WorkExperience()
            //    {
            //        Company = this.WorkExperience.Company,
            //        Detail = this.WorkExperience.Detail,
            //        StartDate = this.WorkExperience.StartDate,
            //        EndDate = this.WorkExperience.EndDate
            //    }
            //};
            //return resume;


            //return this.MemberwiseClone() as ResumeBase;
            //浅拷贝，
            //对于引用类型的成员变量，比如数组、对象等，浅拷贝会进行引用传递。
            //导致对拷贝后的实例赋值时改变原始实例的参数

            //改进
            ItResume itResume=this.MemberwiseClone() as ItResume;
            itResume.WorkExperience = this.WorkExperience.Clone();
            return itResume;
        }
    }
}
