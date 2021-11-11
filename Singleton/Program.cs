using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            int count1 = SingletonSample.Instance.IncreaseCount();
            int count2 = SingletonSample.Instance.IncreaseCount();
            Console.WriteLine($"count1={count1};count2={count2}");
            Console.ReadKey();
        }
    }
}
