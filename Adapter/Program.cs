using System;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer computer = new Computer();
            //computer.SetUsb(new SdReader());//继承接口
            computer.SetUsb(new SdReader(new Sd()));//组合的方式
            computer.ConnectUsb();
            Console.ReadKey();
        }
    }
}
