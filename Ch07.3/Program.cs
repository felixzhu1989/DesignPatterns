using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch07._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Proxy proxy = new Proxy();
            proxy.Request();
            Console.ReadKey();
        }
    }
    //共用接口
    abstract class Subject
    {
        public abstract void Request();
    }
    //真实实体
    class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("真实的请求");
        }
    }
    //代理
    class Proxy : Subject
    {
        private RealSubject realSubject;
        public override void Request()
        {
            if (realSubject == null)
            {
                realSubject = new RealSubject();
            }
            realSubject.Request();
        }
    }
}
