using System;

namespace Ch01._1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("please input numberA:");
                string strNumberA = Console.ReadLine();
                Console.WriteLine("please choose the operate:");
                string strOperate = Console.ReadLine();
                Console.WriteLine("please input numberB:");
                string strNumberB = Console.ReadLine();
                double result = Operation.GetResult(Convert.ToDouble(strNumberA), Convert.ToDouble(strNumberB),
                    strOperate);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Input Error:{ex}");
            }
            Console.ReadKey();
        }
    }

    public class Operation
    {
        public static double GetResult(double numberA, double numberB, string operate)
        {
            double result = 0d;
            switch (operate)
            {
                case "+":
                    result = numberA + numberB;
                    break;
                case "-":
                    result = numberA - numberB;
                    break;
                case "*":
                    result = numberA * numberB;
                    break;
                case "/":
                    result = numberA / numberB;
                    break;
            }
            return result;
        }
    }
}
