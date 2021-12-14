using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch06._2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();
            d1.SetComponent(c);
            d2.SetComponent(d1);
            d2.Operation();
            Console.Read();
        }
    }

    abstract class Component
    {
        public abstract void Operation();
    }

    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("具体对象的操作");
        }
    }

    abstract class Decorator : Component
    {
        protected Component component;
        //设置Component
        public void SetComponent(Component component)
        {
            this.component = component;
        }
        //重写Operation，实际执行的是Component的Operation
        public override void Operation()
        {
            if (component != null)
            {
                component.Operation();
            }
        }
    }

    class ConcreteDecoratorA : Decorator
    {
        //本类独有的变量，区别于ConcreteDecoratorA
        private string addedState;
        public override void Operation()
        {
            ////首先运行原Component的Operation()
            base.Operation();
            //再执行本类的功能，相当于对原Component进行装饰
            addedState = "New State";
            Console.WriteLine("具体装饰对象A的操作");
        }
    }
    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            //首先运行原Component的Operation()
            base.Operation();
            //再执行本类的功能，相当于对原Component进行装饰
            AddedBehavior();
            Console.WriteLine("具体装饰对象B的操作");
        }
        //本类独有的方法，区别于ConcreteDecoratorA
        private void AddedBehavior()
        {
        }
    }
}
