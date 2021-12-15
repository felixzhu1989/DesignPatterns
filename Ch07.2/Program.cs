using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch07._2
{
    class Program
    {
        static void Main(string[] args)
        {
            //娇娇不认识追求她的人，但却可以通过代理人得到礼物
            SchoolGirl jiaojiao = new SchoolGirl();
            jiaojiao.Name = "娇娇";
            Proxy daili = new Proxy(jiaojiao);
            daili.GiveDolls();//实际上礼物是被代理者送出的
            daili.GiveFlowers();
            daili.GiveChocolate();
            Console.ReadKey();
        }
    }
    //送礼物接口
    interface IGiveGift
    {
        void GiveDolls();
        void GiveFlowers();
        void GiveChocolate();
    }
    //代理也实现送礼物接口
    class Proxy : IGiveGift
    {
        Pursuit gg;
        public Proxy(SchoolGirl mm)
        {
            this.gg = new Pursuit(mm);
        }
        public void GiveDolls()
        {
            gg.GiveDolls();//调用追求这去送礼物
        }
        public void GiveFlowers()
        {
            gg.GiveFlowers();
        }
        public void GiveChocolate()
        {
            gg.GiveChocolate();
        }
    }
    //追求者，实现送礼物接口
    class Pursuit:IGiveGift
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
