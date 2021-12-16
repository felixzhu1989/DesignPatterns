using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch08._1
{
    class Program
    {
        static void Main(string[] args)
        {
            IFactory operFactory = new AddFactory();
            Operation oper = operFactory.CreateOperation();
            oper.NumberA = 1;
            oper.NumberB = 2;
            Console.WriteLine(oper.GetResult());
            Console.ReadKey();
        }
    }

    #region 工厂类
    interface IFactory
    {
        Operation CreateOperation();
    }
    class AddFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new OperationAdd();
        }
    }
    class SubFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new OperationSub();
        }
    }
    class MulFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new OperationMul();
        }
    }
    class DivFactory : IFactory
    {
        public Operation CreateOperation()
        {
            return new OperationDiv();
        }
    } 
    #endregion
    #region 计算操作类
    public class Operation
    {
        public double NumberA { get; set; }
        public double NumberB { get; set; }

        public virtual double GetResult()
        {
            return 0;
        }
    }
    public class OperationAdd : Operation
    {
        public override double GetResult()
        {
            return NumberA + NumberB;
        }
    }
    public class OperationSub : Operation
    {
        public override double GetResult()
        {
            return NumberA - NumberB;
        }
    }
    public class OperationMul : Operation
    {
        public override double GetResult()
        {
            return NumberA * NumberB;
        }
    }
    public class OperationDiv : Operation
    {
        public override double GetResult()
        {
            if (NumberB == 0) throw new Exception("The divisor cannot be 0");
            return NumberA / NumberB;
        }
    }
    #endregion
}
