using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderAbstractFactory
{
    public class HighPhoneBuilder:PhoneBuilder
    {
        public override void BuildCpu()
        {
            Phone.Cpu = new HighCpu();
        }

        public override void BuildMem()
        {
            Phone.Mem = new HighMem();
        }

        public override void BuildScreen()
        {
            Phone.Screen = new HighScreen();
        }
    }
}
