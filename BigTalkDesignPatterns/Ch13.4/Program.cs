using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch13._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();
            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();
            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Show();
            Console.ReadKey();
        }
    }
    //Product类——产品类，由多个部件组成。
    class Product
    {
        private IList<string> parts = new List<string>();
        public void Add(string part)//添加产品部件
        {
            parts.Add(part);
        }
        public void Show()
        {
            Console.WriteLine("创建产品---");
            foreach (string part in parts)
            {
                Console.WriteLine(part);//列举产品
            }
        }
    }
    //Builder类——抽象建造者类，确定产品由两个部件PartA和PartB组成，
    //并声明一个得到产品建造后结果的方法GetResult。
    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
    }
    //ConcreteBuilder1类——具体建造者类。
    class ConcreteBuilder1 : Builder
    {
        private Product product = new Product();
        public override void BuildPartA()
        {
            product.Add("部件A");
        }

        public override void BuildPartB()
        {
            product.Add("部件B");
        }

        public override Product GetResult()
        {
            return product;
        }
    }
    //ConcreteBuilder2类——具体建造者类。
    class ConcreteBuilder2 : Builder
    {
        private Product product = new Product();
        public override void BuildPartA()
        {
            product.Add("部件X");
        }

        public override void BuildPartB()
        {
            product.Add("部件Y");
        }

        public override Product GetResult()
        {
            return product;
        }
    }
    //Director类——指挥者类。指挥建造过程
    class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }
}
