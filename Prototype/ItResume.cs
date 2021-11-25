using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Prototype
{
    [Serializable]
   public sealed class ItResume : ResumeBase
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

        public override ResumeBase DeepClone()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream,this);
                stream.Position = 0;
                return bf.Deserialize(stream) as ResumeBase;
            }
            //使用序列化和反序列化的方式实现原型模式
        }
    }
}
