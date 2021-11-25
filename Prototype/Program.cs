using System;

namespace Prototype
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

            //真正意义上的拷贝，深拷贝
            ItResume resume2=resume1.DeepClone() as ItResume;
            resume2.ExpectedSalary = "面议";
            resume2.WorkExperience.Detail = "电商经验丰富";
            resume1.Display();
            Console.WriteLine("*******************************");
            resume2.Display();
            Console.ReadKey();
        }
    }
}
