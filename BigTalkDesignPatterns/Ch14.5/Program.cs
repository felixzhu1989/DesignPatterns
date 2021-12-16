using System;

namespace Ch14._5
{
    //事件委托实现
    //声明一个委托，名称叫“EventHandler（事件处理程序）
    delegate void EventHandler();
    class Program
    {
        static void Main(string[] args)
        {
            Boss huhansan = new Boss();
            StockObserver tongshi1 = new StockObserver("同事1", huhansan);
            NBAObserver tongshi2 = new NBAObserver("同事2", huhansan);
            //将两个不同类的不同方法，委托给老板类的更新
            huhansan.Update += new EventHandler(tongshi1.CloseStockMarket);
            huhansan.Update += new EventHandler(tongshi2.CloseNBADirectSeeding);
            huhansan.SubjectState = "我胡汉三来了";
            huhansan.Notify();
            Console.ReadKey();
        }
    }
    interface ISubject
    {
        void Notify();
        string SubjectState { get; set; }
    }
    //“抽象通知者”由于不希望依赖“抽象观察者”，
    //所以“增加”和“减少”的方法也就没有必要了（抽象观察者已经不存在了）。
    //看股票的同事
    class StockObserver
    {
        private string name;
        private ISubject sub;
        public StockObserver(string name, ISubject sub)
        {
            this.name = name;
            this.sub = sub;
        }
        //关闭股票程序
        public void CloseStockMarket()
        {
            Console.WriteLine($"{sub.SubjectState},{name}关闭股票行情，请继续工作");
        }
    }
    //看NBA的同事
    class NBAObserver
    {
        private string name;
        private ISubject sub;

        public NBAObserver(string name, ISubject sub)
        {
            this.name = name;
            this.sub = sub;
        }
        //关闭NAB直播
        public void CloseNBADirectSeeding()
        {
            Console.WriteLine($"{sub.SubjectState},{name}关闭NBA直播，请继续工作");
        }
    }
    class Boss:ISubject
    {
        //声明一个Update事件，类型为EventHandler委托
        //‘delegate void EventHandler ();’，可以理解为声明了一个特殊的‘类’。
        //而‘public eventEventHandler Update;’可以理解为声明了一个‘类’的变量。
        public event EventHandler Update;
        public string SubjectState { get; set; }
        public void Notify()
        {
            Update();
        }
    }
}
