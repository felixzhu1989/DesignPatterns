using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch06._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Person xc = new Person("小蔡");
            Console.WriteLine("\n第一种装扮：");
            Sneakers pqx = new Sneakers();
            BigTrouser kk = new BigTrouser();
            TShirts dtx = new TShirts();

            pqx.Decorate(xc);
            kk.Decorate(pqx);
            dtx.Decorate(kk);
            dtx.Show();
            Console.ReadKey();
        }
    }
    //“Person”类（ConcreteComponent）
    class Person
    {
        public Person()
        {
        }
        private string name;
        public Person(string name)
        {
            this.name = name;
        }

        public virtual void Show()
        {
            Console.WriteLine($"装扮的{name}");
        }
    }
    class Finery : Person
    {
        protected Person component;
        //打扮
        public void Decorate(Person component)
        {
            this.component = component;
        }

        public override void Show()
        {
            if (component != null)
            {
                component.Show();
            }
        }
    }
    //具体服饰
    class TShirts : Finery
    {
        public override void Show()
        {
            Console.Write("大T恤 ");
            base.Show();
        }
    }
    class BigTrouser : Finery
    {
        public override void Show()
        {
            Console.Write("跨裤 ");
            base.Show();
        }
    }
    class Sneakers : Finery
    {
        public override void Show()
        {
            Console.Write("破球鞋 ");
            base.Show();
        }
    }
}
