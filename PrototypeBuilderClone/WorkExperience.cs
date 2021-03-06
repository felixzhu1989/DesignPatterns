using System;

namespace PrototypeBuilderClone
{
   public class WorkExperience
    {
        public string Company { get; set; }
        public string Detail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public void Display()
        {
            Console.WriteLine("工作经历：");
            Console.WriteLine($"{this.Company}\t{this.StartDate.ToShortDateString()}-{this.EndDate.ToShortDateString()}");
            Console.WriteLine("工作详细：");
            Console.WriteLine(this.Detail);
        }

        public WorkExperience Clone()
        {
            return this.MemberwiseClone() as WorkExperience;
        }
    }
}
