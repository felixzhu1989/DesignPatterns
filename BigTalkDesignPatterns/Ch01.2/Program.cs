using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch01._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //只需要输入运算符号，工厂就实例化出合适的对象，通过多态，返回父类的方式实现了计算器的结果。
            Operation oper = OperationFactory.CreateOperation("+");
            oper.NumberA = 1;
            oper.NumberB = 2;
            double result = oper.GetResult();
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
    //简单工厂模式
    public class OperationFactory
    {
        public static Operation CreateOperation(string operate)
        {
            Operation oper = null;
            switch (operate)
            {
                case "+":
                    oper = new OperationAdd();
                    break;
                case "-":
                    oper = new OperationSub();
                    break;
                case "*":
                    oper = new OperationMul();
                    break;
                case "/":
                    oper = new OperationDiv();
                    break;
            }
            return oper;
        }
    }

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
}
