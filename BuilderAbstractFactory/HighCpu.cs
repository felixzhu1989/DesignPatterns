﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderAbstractFactory
{
    public class HighCpu:Cpu
    {
        public override string Type { get; set; } = "6核12线程";
    }
}