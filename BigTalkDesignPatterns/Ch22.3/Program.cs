using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Ch22._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Abstraction ab = new RefinedAbstraction();
            ab.SetImplementor(new ConcreteImplementorA());
            ab.Operation();
            ab.SetImplementor(new ConcreteImplementorB());
            ab.Operation();
            Console.ReadKey();
        }
    }
    abstract class Implementor
    {
        public abstract void operation();
    }
    class ConcreteImplementorA:Implementor
    {
        public override void operation()
        {
            Console.WriteLine("具体实现A的方法执行");
        }
    }
    class ConcreteImplementorB : Implementor
    {
        public override void operation()
        {
            Console.WriteLine("具体实现B的方法执行");
        }
    }
    class Abstraction
    {
        protected Implementor implementor;

        public void SetImplementor(Implementor implementor)
        {
            this.implementor = implementor;
        }
        public virtual void Operation(){implementor.operation();}
    }
    class RefinedAbstraction : Abstraction
    {
        public override void Operation(){implementor.operation();}
    }
}
