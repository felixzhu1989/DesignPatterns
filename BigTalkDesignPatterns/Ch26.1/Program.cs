using System;
using System.Collections;

namespace Ch26._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int extrinsicstate = 22;
            FlyweightFactory f = new FlyweightFactory();
            Flyweight fx = f.GetFlyweight("X");
            fx.Operation(--extrinsicstate);
            Flyweight fy = f.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);
            Flyweight fz = f.GetFlyweight("Z");
            fz.Operation(--extrinsicstate);
            Flyweight uf = new UnsharedConcreteFlyweight();
            uf.Operation(--extrinsicstate);
            Console.ReadKey();
        }
    }
    abstract class Flyweight
    {
        public abstract void Operation(int extrinsicstate);
    }
    class ConcreteFlyweight:Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine($"具体Flyweight{extrinsicstate}");
        }
    }
    class UnsharedConcreteFlyweight : Flyweight
    {
        public override void Operation(int extrinsicstate)
        {
            Console.WriteLine($"不共享的具体Flyweight{extrinsicstate}");
        }
    }
    class FlyweightFactory
    {
        private Hashtable flyweights = new Hashtable();

        public FlyweightFactory()
        {
            flyweights.Add("X",new ConcreteFlyweight());
            flyweights.Add("Y",new ConcreteFlyweight());
            flyweights.Add("Z",new ConcreteFlyweight());
        }
        public Flyweight GetFlyweight(string key)
        {
            return (Flyweight)flyweights[key];
        }
    }
}
