using System;
using System.Collections.Generic;

namespace Ch20._1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteAggregate a = new ConcreteAggregate();
            a[0] = "大鸟";
            a[1] = "行李";
            a[2] = "老外";
            a[3] = "公交公司内部员工";
            a[4] = "小偷";
            Iterator i = new ConcreteIterator(a);
            object item = i.First();
            while (!i.IsDone())
            {
                Console.WriteLine($"{i.CurrentItem()}请买票");
                i.Next();
            }
            /*
            List<string> b = new List<string>();
            b.Add("大鸟");
            b.Add("行李");
            b.Add("老外");
            b.Add("公交公司内部员工");
            b.Add("小偷");
            foreach (string s in b)
            {
                Console.WriteLine($"{s}请买票");
            }
            */
            Console.ReadKey();
        }
    }
    abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }
    abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
    }

    class ConcreteAggregate : Aggregate
    {
        private List<object> items = new List<object>();
        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }
        public int Count => items.Count;
        public object this[int index] { get => items[index]; set => items.Insert(index, value); }
    }
    class ConcreteIterator : Iterator
    {
        private ConcreteAggregate aggregate;
        private int current = 0;
        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }
        public override object First()
        {
            return aggregate[0];
        }
        public override object Next()
        {
            object ret = null;
            current++;
            if (current < aggregate.Count)
            {
                ret = aggregate[current];
            }
            return ret;
        }
        public override bool IsDone()
        {
            return current >= aggregate.Count ? true : false;
        }
        public override object CurrentItem()
        {
            return aggregate[current];
        }
    }
}
