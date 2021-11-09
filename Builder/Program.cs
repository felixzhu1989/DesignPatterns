using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            IPhoneBuilder phoneBuilder=new PhoneBuilder();
            //链式编程
            Phone phone = phoneBuilder
                .BuildCpu(cpu => { cpu.Type = "8核16线程"; })
                .BuildMem(men => { men.Type = "32G"; })
                .BuildScreen(screen => { screen.Type = "10寸"; })
                .Build();
            phone.Show();
            Console.ReadKey();
        }
    }
}
