using System;

namespace Ch18._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Originator o = new Originator
            {
                State = "On"
            };
            o.Show();
            Caretaker c = new Caretaker
            {
                Memento = o.CreateMemento()
            };
            o.State = "Off";
            o.Show();
            o.SetMemento(c.Memento);
            o.Show();
            Console.ReadKey();
        }
    }
    //发起人类
    class Originator
    {
        public string State { get; set; }

        public Memento CreateMemento()
        {
            return new Memento(State);
        }
        public void SetMemento(Memento memento)
        {
            State = memento.State;
        }
        public void Show()
        {
            Console.WriteLine($"State:{State}");
        }
    }
    //备忘录类
    class Memento
    {
        public string State { get; }
        public Memento(string state)
        {
            this.State = state;
        }
    } 
    //管理者类
    class Caretaker
    {
        public Memento Memento { get; set; }
    }
}
