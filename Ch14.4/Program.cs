using System;
using System.Collections.Generic;

namespace Ch14._4
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteSubject s = new ConcreteSubject();
            s.Attach(new ConcreteObserver(s,"x"));
            s.Attach(new ConcreteObserver(s,"y"));
            s.Attach(new ConcreteObserver(s,"z"));
            s.SubjectState = "ABC";
            s.Notify();
            Console.ReadKey();
        }
    }
    abstract class Observer
    {
        public abstract void Update();
    }
    abstract class Subject
    {
        private IList<Observer> observers = new List<Observer>();
        //增加观察者
        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }
        //移除观察者
        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }
        //通知
        public void Notify()
        {
            foreach (Observer o in observers)
            {
                o.Update();
            }
        }
    }
    class ConcreteSubject : Subject
    {
        public string SubjectState { get; set; }
    }
    class ConcreteObserver : Observer
    {
        private string name;
        private string observerState;
        public ConcreteSubject Subject { get; set; }
        public ConcreteObserver(ConcreteSubject subject, string name)
        {
            this.name = name;
            this.Subject = subject;
        }
        public override void Update()
        {
            observerState = Subject.SubjectState;
            Console.WriteLine($"观察者{name}的新状态是{observerState}");
        }
    }
}
