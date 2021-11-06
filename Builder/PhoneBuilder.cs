using System;

namespace Builder
{
   public class PhoneBuilder: IPhoneBuilder
    {
       private Phone _phone;
       private Cpu _cpu;
       private Mem _mem;
       private Screen _screen;

       public IPhoneBuilder BuildCpu(Action<Cpu> builderCpuDelegate)
       {
           _cpu=new Cpu();
            builderCpuDelegate?.Invoke(_cpu);//通过委托取获取cpu的参数
           return this;
       }
        public IPhoneBuilder BuildMem(Action<Mem> builderMemDelegate)
        {
            _mem = new Mem();
            builderMemDelegate?.Invoke(_mem);
            return this;
        }
        public IPhoneBuilder BuildScreen(Action<Screen> builderScreenDelegate)
        {
            _screen = new Screen();
            builderScreenDelegate?.Invoke(_screen);
            return this;
        }

        public Phone Build()
        {
            _phone = new Phone
            {
                Cpu = _cpu ?? new Cpu{ Type = "4核8线程" },
                Mem = _mem ?? new Mem{ Type = "8G" },
                Screen = _screen ?? new Screen{ Type = "7寸" }
            };
            return _phone;
        }
    }
}
