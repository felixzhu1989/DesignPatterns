using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            IResumeBuilder resumeBuilder = new ResumeBuilder().BuildBasicInfo(resume =>
                {
                    resume.Name = "张三";
                    resume.Age = 18;
                    resume.Gender = "男";
                    resume.ExpectedSalary = "100W";
                })
                .BuildWorkExperience(work =>
                {
                    work.Company = "A公司";
                    work.Detail = "负责XX系统开发，精通YYY....";
                    work.StartDate = DateTime.Parse("2019-1-1");
                    work.EndDate = DateTime.Parse("2020-1-1");
                });
            ResumeBase resume1 = resumeBuilder.Build();
            //重新Build
            ResumeBase resume2 = resumeBuilder.BuildBasicInfo(resume =>
            {
                resume.ExpectedSalary = "面议";
            }).BuildWorkExperience(work =>
            {
                work.Detail = "电商经验丰富";
            }).Build();
            resume1.Display();
            Console.WriteLine("*******************************");
            resume2.Display();
            Console.ReadKey();
        }
    }
}
