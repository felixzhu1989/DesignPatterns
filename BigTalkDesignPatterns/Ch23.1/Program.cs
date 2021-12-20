using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch23._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //如果用户多了，请求多了，就容易乱了。
            Barbecuer boy = new Barbecuer();
            boy.BakeMutton();
            boy.BakeMutton();
            boy.BakeChickenWing();

            Console.ReadKey();
        }
    }
    //烤肉串者
    public class Barbecuer
    {
        public void BakeMutton()
        {
            Console.WriteLine("靠羊肉串");
        }
        public void BakeChickenWing()
        {
            Console.WriteLine("靠鸡翅");
        }
    }
}
