using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch08._2
{
    //重复代码多
    class Program
    {
        static void Main(string[] args)
        {
            LeiFeng studentA = SimplyFactory.CreateLeifeng("学雷锋的大学生");
            LeiFeng studentB = SimplyFactory.CreateLeifeng("学雷锋的大学生");
            LeiFeng volunteerA = SimplyFactory.CreateLeifeng("社区志愿者");
            studentA.Sweep();
            studentB.Wash();
            volunteerA.BuyRice();
        }
    }

    class SimplyFactory
    {
        public static LeiFeng CreateLeifeng(string type)
        {
            LeiFeng result = null;
            switch (type)
            {
                case "学雷锋的大学生":
                    result = new Undergraduate();
                    break;
                case "社区志愿者":
                    result = new Volunteer();
                    break;
            }
            return result;
        }
    }

    class LeiFeng
    {
        public void Sweep()
        {
            Console.WriteLine("扫地");
        }

        public void Wash()
        {
            Console.WriteLine("洗衣");
        }

        public void BuyRice()
        {
            Console.WriteLine("买米");
        }
    }

    class Undergraduate : LeiFeng
    {
    }

    class Volunteer : LeiFeng
    {
    }


}
