using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch07._1
{
    //卓贾易直接追娇娇
    class Program
    {
        static void Main(string[] args)
        {
            SchoolGirl jiaojiao = new SchoolGirl();
            jiaojiao.Name = "娇娇";
            //但是实际上，娇娇并不认识卓贾易，因此需要一个代理
            Pursuit zhuojiayi = new Pursuit(jiaojiao);
            zhuojiayi.GiveDolls();
            zhuojiayi.GiveFlowers();
            zhuojiayi.GiveChocolate();
            Console.ReadKey();
        }
    }
    //追求者
    class Pursuit
    {
        private SchoolGirl mm;

        public Pursuit(SchoolGirl mm)
        {
            this.mm = mm;
        }

        public void GiveDolls()
        {
            Console.WriteLine($"{mm.Name} 送你玩具");
        }
        public void GiveFlowers()
        {
            Console.WriteLine($"{mm.Name} 送你鲜花");
        }
        public void GiveChocolate()
        {
            Console.WriteLine($"{mm.Name} 送你巧克力");
        }
    }
    class SchoolGirl
    {
        public string Name { get; set; }
    }
}
