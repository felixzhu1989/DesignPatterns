using System;
using System.Collections.Generic;

namespace Ch14._3
{
    //解耦实践二
    class Program
    {
        static void Main(string[] args)
        {
            Boss huhansan = new Boss();
            Observer tongshi1 = new StockObserver("同事1", huhansan);
            Observer tongshi2 = new NBAObserver("同事2", huhansan);
            huhansan.Attach(tongshi1);
            huhansan.Attach(tongshi2);
            huhansan.Detach(tongshi2);//没有被通知到，摸鱼被发现了
            huhansan.SubjectState = "我胡汉三来了";
            huhansan.Notify();
            Console.ReadKey();
        }
    }
    //增加了抽象通知者接口
    interface ISubject
    {
        void Attach(Observer observer);
        void Detach(Observer observer);
        void Notify();
        string SubjectState { get; set; }
    }
    abstract class Observer
    {
        protected string name;
        //原来的前台改成了抽象的通知者
        protected ISubject sub;

        public Observer(string name, ISubject sub)
        {
            this.name = name;
            this.sub = sub;
        }
        public abstract void Update();
    }
    //具体的通知者类可能是前台，也可能是老板，它们也许有各自的一些方法，
    //但对于通知者来说，它们是一样的，所以它们都去实现这个接口。
    class Boss : ISubject
    {
        private IList<Observer> observers = new List<Observer>();
        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }
        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (Observer o in observers)
            {
                o.Update();
            }
        }
        public string SubjectState { get; set; }
    }
    class Secretary : ISubject
    {
        private IList<Observer> observers = new List<Observer>();
        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }
        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }
        public void Notify()
        {
            foreach (Observer o in observers)
            {
                o.Update();
            }
        }
        public string SubjectState { get; set; }
    }
    //对于具体的观察者，需更改的地方就是把与‘前台’耦合的地方都改成针对抽象通知者。
    class StockObserver : Observer
    {
        public StockObserver(string name, ISubject sub) : base(name, sub)
        {
        }
        public override void Update()
        {
            Console.WriteLine($"{sub.SubjectState},{name}关闭股票行情，请继续工作");
        }
    }
    class NBAObserver : Observer
    {
        public NBAObserver(string name, ISubject sub) : base(name, sub)
        {
        }
        public override void Update()
        {
            Console.WriteLine($"{sub.SubjectState},{name}关闭NBA直播，请继续工作");
        }
    }
}
