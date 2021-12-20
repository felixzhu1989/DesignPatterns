using System;

namespace Ch25._1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteMediator m = new ConcreteMediator();//中介
            ConcreteColleague1 c1 = new ConcreteColleague1(m);//让两个具体的同事只认识中介
            ConcreteColleague2 c2 = new ConcreteColleague2(m);
            m.Colleague1 = c1;//让中介也认识同事
            m.Colleague2 = c2;
            c1.Send("吃过饭了吗？");//发送的消息都是通过中介
            c2.Send("没有呢，你打算请客？");
            Console.ReadKey();
        }
    }
    abstract class Mediator
    {
        public abstract void Send(string nessage, Colleague colleague);
    }
    abstract class Colleague
    {
        protected Mediator mediator;
        public Colleague(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }
    class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator) : base(mediator) { }
        public void Send(string message)
        {
            mediator.Send(message, this);
        }
        public void Notify(string message)
        {
            Console.WriteLine($"同事1得到消息:{message}");
        }
    }
    class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator) : base(mediator) { }
        public void Send(string message)
        {
            mediator.Send(message, this);
        }
        public void Notify(string message)
        {
            Console.WriteLine($"同事2得到消息:{message}");
        }
    }
    class ConcreteMediator : Mediator
    {
        public ConcreteColleague1 Colleague1 { get; set; }
        public ConcreteColleague2 Colleague2 { get; set; }

        public override void Send(string message, Colleague colleague)
        {
            if(colleague==Colleague1)Colleague2.Notify(message);
            else Colleague1.Notify(message);
        }
    }
}
