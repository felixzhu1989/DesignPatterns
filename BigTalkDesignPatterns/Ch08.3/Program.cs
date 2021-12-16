using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch08._3
{
    class Program
    {
        static void Main(string[] args)
        {
            //客户端的代码精简了很多
            //尽管如果要换成‘社区志愿者’也还是要修改代码，只需要修改一处(客户端)就可以了。
            IFactory factory = new UndergraduateFactory();//此处也是可以通过反射来实现的
            LeiFeng student = factory.CreateLeiFeng();
            student.BuyRice();
            student.Sweep();
            student.Wash();
        }
    }

    #region 雷锋工厂

    interface IFactory
    {
        LeiFeng CreateLeiFeng();
    }
    class UndergraduateFactory:IFactory
    {
        public LeiFeng CreateLeiFeng()
        {
            return new Undergraduate();
        }
    }

    class VolunteerFactory : IFactory
    {
        public LeiFeng CreateLeiFeng()
        {
            return new Volunteer();
        }
    }
    #endregion

    #region 学雷锋
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
    #endregion
}
