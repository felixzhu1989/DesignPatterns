using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch02._5
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context;
            //实例化不同的策略，最终在调用ContextInterface()时所获得的结果不同
            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();
            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();
            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();
        }
    }
    //抽象算法类
    public abstract class Strategy
    {
        //算法方法
        public abstract void AlgorithmInterface();
    }

    class ConcreteStrategyA : Strategy
    {
        //算法A实现方法
        public override void AlgorithmInterface()
        {
            Console.WriteLine("算法A实现");
        }
    }
    class ConcreteStrategyB : Strategy
    {
        //算法A实现方法
        public override void AlgorithmInterface()
        {
            Console.WriteLine("算法B实现");
        }
    }
    class ConcreteStrategyC : Strategy
    {
        //算法A实现方法
        public override void AlgorithmInterface()
        {
            Console.WriteLine("算法C实现");
        }
    }
    //上下文
    public class Context
    {
        private Strategy strategy;
        //聚合表示一种弱的‘拥有’关系，体现的是A对象可以包含B对象
        //初始化传入具体的策略对象，Context拥有算法Strategy
        public Context(Strategy strategy)
        {
            this.strategy = strategy;
        }
        //上下文接口,根据具体的策略调用其算法的方法
        public void ContextInterface()
        {
            strategy.AlgorithmInterface();
        }
    }
}
