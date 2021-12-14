using System;

namespace Ch06._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person xc = new Person("小蔡");
            Console.WriteLine("\n第一种装扮：");
            Finery dtx = new TShirts();
            Finery kk = new BigTrouser();
            Finery pqx = new Sneakers();

            dtx.Show();
            kk.Show();
            pqx.Show();
            xc.Show();

            Console.ReadKey();
        }
    }

    class Person
    {
        private string name;
        public Person(string name)
        {
            this.name = name;
        }

        public void Show()
        {
            Console.WriteLine($"装扮的{name}");
        }
    }

    abstract class Finery
    {
        public abstract void Show();
    }

    class TShirts : Finery
    {
        public override void Show()
        {
            Console.Write("大T恤 ");
        }
    }
    class BigTrouser : Finery
    {
        public override void Show()
        {
            Console.Write("跨裤 ");
        }
    }
    class Sneakers : Finery
    {
        public override void Show()
        {
            Console.Write("破球鞋 ");
        }
    }
}
