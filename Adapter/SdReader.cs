using System.Security.Cryptography;

namespace Adapter
{
    ////读卡器，适配器模式，继承SD和IUsb
    //public class SdReader:Sd,IUsb
    //{
    //    public void Request()
    //    {
    //        this.ReadWrite();
    //    }
    //}

    //读卡器，适配器模式，使用组合的方式，通过构造器函数传递Sd进来
    public class SdReader : IUsb
    {
        private Sd _sd;

        public SdReader(Sd sd)
        {
            _sd = sd;
        }
        public void Request()
        {
            _sd.ReadWrite();
        }
    }
}
