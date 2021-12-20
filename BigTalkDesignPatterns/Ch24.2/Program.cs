using System;

namespace Ch24._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Handler h1 = new ConcreteHandler1();
            Handler h2 = new ConcreteHandler2();
            Handler h3 = new ConcreteHandler3();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);
            int[] requests = { 2, 5, 22, 18, 3, 27, 20 };
            foreach (int request in requests)
            {
                h1.HandleRequest(request);
            }

            Console.ReadKey();
        }
    }
    abstract class Handler
    {
        protected Handler successor;
        //设置继任者
        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }
        //处理请求的抽象方法
        public abstract void HandleRequest(int request);
    }
    class ConcreteHandler1:Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                Console.WriteLine($"{this.GetType().Name}处理请求{request}");
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
    class ConcreteHandler2 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine($"{this.GetType().Name}处理请求{request}");
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }
    class ConcreteHandler3 : Handler
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine($"{this.GetType().Name}处理请求{request}");
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

}
