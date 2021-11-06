using System;

namespace Builder
{
   public interface IPhoneBuilder
   {
       IPhoneBuilder BuildCpu(Action<Cpu> buildCpuDelegate);
       IPhoneBuilder BuildMem(Action<Mem> buildMemDelegate);
       IPhoneBuilder BuildScreen(Action<Screen> buildScreenDelegate);
       Phone Build();
   }
}
