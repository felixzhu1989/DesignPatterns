using System;

namespace Ch12._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //用户需要了解股票，国债，地产情况，需要参与这些项目到的具体买卖，耦合性很高
            /*
            Stock1 gu1 = new Stock1();
            Stock2 gu2 = new Stock2();
            NationalDebt1 nd1 = new NationalDebt1();
            Realty1 rt1 = new Realty1();
            gu1.Buy();
            gu2.Buy();
            nd1.Buy();
            rt1.Buy();
            gu1.Sell();
            gu2.Sell();
            nd1.Sell();
            rt1.Sell();
            */
            //用户无需关心具体的投资品类，只需要购买基金就行了
            Fund jijin = new Fund();
            jijin.BuyFund();
            jijin.SellFund();
            Console.ReadKey();
        }
    }
    //增加基金类
    class Fund
    {
        //基金类需要了解所有的股票或其他的投资方式的方法或属性进行组合
        Stock1 gu1;
        Stock2 gu2;
        NationalDebt1 nd1;
        Realty1 rt1;
        public Fund()
        {
            gu1 = new Stock1();
            gu2 = new Stock2();
            nd1 = new NationalDebt1();
            rt1 = new Realty1();
        }
        public void BuyFund()
        {
            gu1.Buy();
            gu2.Buy();
            nd1.Buy();
            rt1.Buy();
        }
        public void SellFund()
        {
            gu1.Sell();
            gu2.Sell();
            nd1.Sell();
            rt1.Sell();
        }
    }
    class Stock1
    {
        public void Sell()
        {
            Console.WriteLine("股票1卖出");
        }
        public void Buy()
        {
            Console.WriteLine("股票1买入");
        }
    }
    class Stock2
    {
        public void Sell()
        {
            Console.WriteLine("股票2卖出");
        }
        public void Buy()
        {
            Console.WriteLine("股票2买入");
        }
    }
    class NationalDebt1
    {
        public void Sell()
        {
            Console.WriteLine("国债1卖出");
        }
        public void Buy()
        {
            Console.WriteLine("国债1买入");
        }
    }
    class Realty1
    {
        public void Sell()
        {
            Console.WriteLine("地产1卖出");
        }
        public void Buy()
        {
            Console.WriteLine("地产1买入");
        }
    }
}
