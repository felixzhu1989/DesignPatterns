using System;

namespace Ch16._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Context c = new Context(new ConcreteStateA());
            c.Request();
            c.Request();
            c.Request();
            c.Request();
            Console.ReadKey();
        }
    }
    abstract class State
    {
        public abstract void Handle(Context context);
    }
    //具体状态
    class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            //设置ConcreteStateA的下一个状态为ConcreteStateB
            context.State = new ConcreteStateB();
        }
    }
    class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            //设置ConcreteStateB的下一个状态为ConcreteStateA
            context.State = new ConcreteStateA();
        }
    }
    class Context
    {
        private State state;
        //定义Context的初始状态
        public Context(State state)
        {
            this.state = state;
        }
        public State State
        {
            get => state;
            set
            {
                state = value;
                Console.WriteLine($"当前状态:{state.GetType().Name}");
            }
        }
        //对请求做处理，并设置下一个状态
        public void Request()
        {
            state.Handle(this);
        }
    }
    
}
