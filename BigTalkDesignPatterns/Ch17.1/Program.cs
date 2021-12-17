using System;

namespace Ch17._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Target target = new Adapter();
            target.Request();
            Console.ReadKey();
        }
    }
    class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("普通请求");
        }
    }
    class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("特殊请求");
        }
    }

    class Adapter : Target
    {
        private Adaptee adaptee = new Adaptee();
        public override void Request()
        {
            adaptee.SpecificRequest();
        }
    }
}
