using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderAbstractFactory
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
