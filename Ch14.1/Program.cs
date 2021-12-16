using System;
using System.Collections.Generic;

namespace Ch14._1
{
    //双向耦合的代码
    class Program
    {
        static void Main(string[] args)
        {
            Secretary tongzhizhe = new Secretary();
            StockObserver tongshi1 = new StockObserver("同事1", tongzhizhe);
            StockObserver tongshi2 = new StockObserver("同事2", tongzhizhe);
            //记下两位同事
            tongzhizhe.Attach(tongshi1);
            tongzhizhe.Attach(tongshi2);
            //发现老板回来
            tongzhizhe.SecretaryAction = "老板来了";
            tongzhizhe.Notify();
            Console.ReadKey();
        }
    }
    //前台秘书
    class Secretary
    {
        private IList<StockObserver> observers = new List<StockObserver>();
        //增加，有几个同事请前台帮忙
        public void Attach(StockObserver observer)
        {
            observers.Add(observer);
        }
        //通知，老板来了就给所有登记的同时发送消息
        public void Notify()
        {
            foreach (StockObserver o in observers)
            {
                o.Update();
            }
        }
        //前台状态
        public string SecretaryAction { get; set; }
    }
    //看股票的同事
    class StockObserver
    {
        private string name;
        private Secretary sub;
        public StockObserver(string name, Secretary sub)
        {
            this.name = name;
            this.sub = sub;
        }
        //得到前台通知就行动
        public void Update()
        {
            Console.WriteLine($"{sub.SecretaryAction},{name}关闭股票行情，请继续工作");
        }
    }
}
