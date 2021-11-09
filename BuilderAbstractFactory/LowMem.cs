using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderAbstractFactory
{
   public class LowMem:Mem
    {
        public override string Type { get; set; } = "2G";
    }
}
