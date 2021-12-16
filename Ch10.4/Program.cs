using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch10._4
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractClass c;
            c = new ConcreteClassA();
            c.TemplateMethod();
            c = new ConcreteClassB();
            c.TemplateMethod();
            Console.ReadKey();
        }
    }
    abstract class AbstractClass
    {
        //一些抽象行为放到子类去实现
        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();
        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            Console.WriteLine("");
        }
    }
    class ConcreteClassA : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("具体类A方法1实现");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("具体类A方法2实现");
        }
    }
    class ConcreteClassB : AbstractClass
    {
        public override void PrimitiveOperation1()
        {
            Console.WriteLine("具体类B方法1实现");
        }

        public override void PrimitiveOperation2()
        {
            Console.WriteLine("具体类B方法2实现");
        }
    }
}
