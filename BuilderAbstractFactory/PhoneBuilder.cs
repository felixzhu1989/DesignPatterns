using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderAbstractFactory
{
    public abstract class PhoneBuilder
    {
        protected Phone Phone;
        public PhoneBuilder()
        {
            Phone = new Phone();
        }

        public abstract void BuildCpu();//构建部件
        public abstract void BuildMem();
        public abstract void BuildScreen();

        public Phone Build()//组装部件
        {
            BuildCpu();
            BuildMem();
            BuildScreen();
            return Phone;
        }
    }
}
