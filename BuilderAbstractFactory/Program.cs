﻿using System;

namespace BuilderAbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBuilder highPhoneBuilder = new HighPhoneBuilder();
            Phone highPhone = highPhoneBuilder.Build();
            highPhone.Show();
            Console.WriteLine("----");
            PhoneBuilder lowPhoneBuilder = new LowPhoneBuilder();
            Phone lowPhone = lowPhoneBuilder.Build();
            lowPhone.Show();
            Console.ReadKey();
        }
    }
}
