using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //由于facade的作用，客户端可以根本不知道三个子系统类的存在
            Facade facade = new Facade();
            facade.MethodA();
            facade.MethodB();
            Console.ReadKey();
        }
    }
    #region 外观类
    class Facade
    {
        private SubSystem1 one;
        private SubSystem2 two;
        private SubSystem3 three;
        private SubSystem4 four;
        public Facade()
        {
            one = new SubSystem1();
            two = new SubSystem2();
            three = new SubSystem3();
            four = new SubSystem4();
        }
        public void MethodA()
        {
            Console.WriteLine("方法组A:");
            one.Method1();
            two.Method2();
        }
        public void MethodB()
        {
            Console.WriteLine("方法组B:");
            three.Method3();
            four.Method4();
        }
    }
    #endregion
    #region 四个子系统
    class SubSystem1
    {
        public void Method1()
        {
            Console.WriteLine("子系统1方法1");
        }
    }
    class SubSystem2
    {
        public void Method2()
        {
            Console.WriteLine("子系统2方法2");
        }
    }
    class SubSystem3
    {
        public void Method3()
        {
            Console.WriteLine("子系统3方法3");
        }
    }
    class SubSystem4
    {
        public void Method4()
        {
            Console.WriteLine("子系统4方法4");
        }
    }
    #endregion
}
