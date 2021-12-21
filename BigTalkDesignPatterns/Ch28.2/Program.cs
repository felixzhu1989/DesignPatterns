using System;
using System.Collections.Generic;

namespace Ch28._2
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjetStructure o = new ObjetStructure();
            o.Attach(new Man());
            o.Attach(new Woman());
            Success v1 = new Success();
            o.Display(v1);
            Failing v2 = new Failing();
            o.Display(v2);
            Amativeness v3 = new Amativeness();
            o.Display(v3);
            Marriage v4 = new Marriage();
            o.Display(v4);
            Console.ReadKey();
        }
    }
    abstract class Person
    {
        public abstract void Accept(Action visitor);
    }
    class Man : Person
    {
        public override void Accept(Action visitor)
        {
            visitor.GetManConclusion(this);//第一次分派
        }
    }
    class Woman : Person
    {
        public override void Accept(Action visitor)
        {
            visitor.GetWomanConclusion(this);
        }
    }
    abstract class Action
    {
        public abstract void GetManConclusion(Man concreteElementA);//第二次分派
        public abstract void GetWomanConclusion(Woman concreteElementB);
    }
    class Success:Action
    {
        public override void GetManConclusion(Man concreteElementA)
        {
            Console.WriteLine($"{concreteElementA.GetType().Name},{this.GetType().Name}时，背后多半有一个伟大的女人。");
        }
        public override void GetWomanConclusion(Woman concreteElementB)
        {
            Console.WriteLine($"{concreteElementB.GetType().Name},{this.GetType().Name}时，背后大多有一个不成功的男人。");
        }
    }
    class Failing : Action
    {
        public override void GetManConclusion(Man concreteElementA)
        {
            Console.WriteLine($"{concreteElementA.GetType().Name},{this.GetType().Name}时，闷头喝酒，谁也不用劝。");
        }
        public override void GetWomanConclusion(Woman concreteElementB)
        {
            Console.WriteLine($"{concreteElementB.GetType().Name},{this.GetType().Name}时，眼泪汪汪，谁也劝不了。");
        }
    }
    class Amativeness : Action
    {
        public override void GetManConclusion(Man concreteElementA)
        {
            Console.WriteLine($"{concreteElementA.GetType().Name},{this.GetType().Name}时，凡事不懂也要装懂。");
        }
        public override void GetWomanConclusion(Woman concreteElementB)
        {
            Console.WriteLine($"{concreteElementB.GetType().Name},{this.GetType().Name}时，遇事懂也装作不懂。");
        }
    }
    class Marriage : Action
    {
        public override void GetManConclusion(Man concreteElementA)
        {
            Console.WriteLine($"{concreteElementA.GetType().Name},{this.GetType().Name}时，感慨道：恋爱游戏终结时，‘有妻徒刑’遥无期。");
        }
        public override void GetWomanConclusion(Woman concreteElementB)
        {
            Console.WriteLine($"{concreteElementB.GetType().Name},{this.GetType().Name}时，欣慰曰：爱情长跑路漫漫，婚姻保险保平安。");
        }
    }
    class ObjetStructure
    {
        private List<Person> elements = new List<Person>();

        public void Attach(Person element)
        {
            elements.Add(element);
        }
        public void Detach(Person element)
        {
            elements.Remove(element);
        }
        public void Display(Action visitor)
        {
            foreach (Person e in elements)
            {
                e.Accept(visitor);
            }
        }
    }
}
