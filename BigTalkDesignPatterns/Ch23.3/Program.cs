using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace Ch23._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver r = new Receiver();
            Command c = new ConcreteCommand(r);
            Invoker i = new Invoker();
            i.SetCommand(c);
            i.ExecuteCommand();
            Console.ReadKey();
        }
    }
    class Receiver
    {
        public void Action()
        {
            Console.WriteLine("执行请求！");
        }
    }
    abstract class Command
    {
        protected Receiver receiver;

        public Command(Receiver receiver)
        {
            this.receiver = receiver;
        }
        public abstract void Execute();
    }
    class ConcreteCommand:Command
    {
        public ConcreteCommand(Receiver receiver) : base(receiver) { }
        public override void Execute()
        {
            receiver.Action();
        }
    }
    class Invoker
    {
        private Command command;
        public void SetCommand(Command command)
        {
            this.command = command;
        }
        public void ExecuteCommand()
        {
            command.Execute();
        }
    }
}
