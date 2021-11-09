using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderAbstractFactory
{
   public class HighMem:Mem
    {
        public override string Type { get; set; } = "8G";
    }
}
