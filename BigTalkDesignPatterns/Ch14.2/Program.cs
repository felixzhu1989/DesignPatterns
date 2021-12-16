using System;
using System.Collections.Generic;

namespace Ch14._2
{
    //解耦实践一
    class Program
    {
        static void Main(string[] args)
        {
            Secretary tongzhizhe = new Secretary();
            Observer tongshi1 = new StockObserver("同事1", tongzhizhe);
            Observer tongshi2 = new NBAObserver("同事2", tongzhizhe);
            //记下两位同事
            tongzhizhe.Attach(tongshi1);
            tongzhizhe.Attach(tongshi2);
            //发现老板回来
            tongzhizhe.SecretaryAction = "老板来了";
            tongzhizhe.Notify();
            Console.ReadKey();
        }
    }
    //前台秘书,把所有的与具体观察者耦合的地方都改成了‘抽象观察者’。
    class Secretary
    {
        private IList<Observer> observers = new List<Observer>();
        //增加，针对抽象编程，减少与具体类的耦合
        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }
        public void Notify()
        {
            foreach (Observer o in observers)
            {
                o.Update();
            }
        }
        public string SecretaryAction { get; set; }
    }
    //增加了抽象的观察者
    abstract class Observer
    {
        protected string name;
        protected Secretary sub;

        public Observer(string name, Secretary sub)
        {
            this.name = name;
            this.sub = sub;
        }
        public abstract void Update();
    }
    //具体观察者
    class StockObserver : Observer
    {
        public StockObserver(string name, Secretary sub) : base(name, sub)
        {
        }
        public override void Update()
        {
            Console.WriteLine($"{sub.SecretaryAction},{name}关闭股票行情，请继续工作");
        }
    }
    class NBAObserver : Observer
    {
        public NBAObserver(string name, Secretary sub) : base(name, sub)
        {
        }
        public override void Update()
        {
            Console.WriteLine($"{sub.SecretaryAction},{name}关闭NBA直播，请继续工作");
        }
    }
}
