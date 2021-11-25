﻿namespace BuilderAbstractFactory
{
   public class LowPhoneBuilder:PhoneBuilder
    {
        public override void BuildCpu()
        {
            Phone.Cpu = new LowCpu();
        }

        public override void BuildMem()
        {
            Phone.Mem = new LowMem();
        }

        public override void BuildScreen()
        {
            Phone.Screen = new LowScreen();
        }
    }
}
