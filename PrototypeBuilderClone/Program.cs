using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeBuilderClone
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
            ItResume resume2=resume1.Clone() as ItResume;//克隆后修改参数
            resume2.ExpectedSalary = "面议";
            resume2.WorkExperience.Detail = "电商经验丰富";
            resume1.Display();
            Console.WriteLine("*******************************");
            resume2.Display();
            Console.ReadKey();
        }
    }
}
