using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch09._2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcretePrototype1 p1 = new ConcretePrototype1("I");
            ConcretePrototype1 c1 = p1.Clone() as ConcretePrototype1;
            Console.WriteLine($"Cloned:{c1.Id}");
            Console.ReadKey();
        }
    }
    //原型类
    abstract class Prototype
    {
        private string id;

        protected Prototype(string id)
        {
            this.id = id;
        }

        public string Id
        {
            get => id;
        }
        //抽象类关键就是有这个Clone方法
        public abstract Prototype Clone();
    }
    //具体原型
    class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(string id):base(id)
        {
        }

        public override Prototype Clone()
        {
            /* 创建当前对象的浅拷贝副本，方法是创建一个新的对象
                然后将当前对象的非静态字段复制到该新的对象
                如果字段是值类型，则对该字段执行逐位复制
                如果字段是引用类型，则复制引用但不复制引用对象
                因此，原始对象及其副本引用同一个对象
            */
            return (Prototype)this.MemberwiseClone();
        }
    }
}
