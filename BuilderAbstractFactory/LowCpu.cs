using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderAbstractFactory
{
   public class LowCpu:Cpu
    {
        public override string Type { get; set; } = "双核4线程";
    }
}
