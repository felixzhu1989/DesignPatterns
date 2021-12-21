using System;
using System.Collections.Generic;

namespace Ch28._1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            Person man1 = new Man();
            man1.Action = "成功";
            persons.Add(man1);
            Person woman1 = new Woman();
            woman1.Action = "失败";
            persons.Add(woman1);
            Person man2 = new Man();
            man2.Action = "恋爱";
            persons.Add(man2);
            Person woman2 = new Woman();
            woman2.Action = "恋爱";
            persons.Add(woman2);
            foreach (Person item in persons)
            {
                item.GetConclusion();
            }
            Console.ReadKey();
        }
    }
    abstract class Person
    {
        public string Action { get; set; }
        //得到结论或反应
        public abstract void GetConclusion();
    }
    class Man:Person
    {
        public override void GetConclusion()
        {
            if (Action == "成功")
            {
                Console.WriteLine($"{this.GetType().Name},{Action}时，背后多半有一个伟大的女人。");
            }
            else if (Action == "失败")
            {
                Console.WriteLine($"{this.GetType().Name},{Action}时，闷头喝酒，谁也不用劝。");
            }
            else if (Action == "恋爱")
            {
                Console.WriteLine($"{this.GetType().Name},{Action}时，凡事不懂也要装懂。");
            }
        }
    }
    class Woman : Person
    {
        public override void GetConclusion()
        {
            if (Action == "成功")
            {
                Console.WriteLine($"{this.GetType().Name},{Action}时，背后大多有一个不成功的男人。");
            }
            else if (Action == "失败")
            {
                Console.WriteLine($"{this.GetType().Name},{Action}时，眼泪汪汪，谁也劝不了。");
            }
            else if (Action == "恋爱")
            {
                Console.WriteLine($"{this.GetType().Name},{Action}时，遇事懂也装作不懂。");
            }
        }
    }
}
