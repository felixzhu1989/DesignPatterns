using System;
using System.Collections.Generic;

namespace Ch27._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();
            List<AbstractExpression> list = new List<AbstractExpression>();
            list.Add(new TerminalExpression());
            list.Add(new NonterminalExpression());
            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }
            Console.ReadKey();
        }
    }
    class Context
    {
        public string Input { get; set; }
        public string Output { get; set; }
    }
    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }
    class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("终端解释器");
        }
    }
    class NonterminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("非终端解释器");
        }
    }
}
