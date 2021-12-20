using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch22._2
{
    class Program
    {
        static void Main(string[] args)
        {
            HandsetBrand ab;
            ab = new HandsetBrandN();
            ab.SetHandsetSoft(new HandsetGame());
            ab.Run();
            ab.SetHandsetSoft(new HandsetAddressList());
            ab.Run();
            ab = new HandsetBrandM();
            ab.SetHandsetSoft(new HandsetGame());
            ab.Run();
            Console.Read();
        }
    }
    //手机软件
    abstract class HandsetSoft
    {
        public abstract void Run();
    }
    class HandsetGame:HandsetSoft
    {
        public override void Run()
        {
            Console.WriteLine("运行手机游戏");
        }
    }
    class HandsetAddressList : HandsetSoft
    {
        public override void Run()
        {
            Console.WriteLine("运行手机通讯录");
        }
    }
    //现在如果要增加一个功能，比如MP3音乐播放功能，那么只要增加这个类就行了。
    //不会影响其他任何类。类的个数也只是增加一个
    class HandsetMP3 : HandsetSoft
    {
        public override void Run()
        {
            Console.WriteLine("运行手机MP3播放器");
        }
    }
    //手机品牌
    abstract class HandsetBrand
    {
        protected HandsetSoft soft;
        //设置手机软件(在机器中安装软件后才能运行)
        public void SetHandsetSoft(HandsetSoft soft)
        {
            this.soft = soft;
        }
        //运行
        public abstract void Run();
    }
    class HandsetBrandN : HandsetBrand
    {
        public override void Run()
        {
            soft.Run();
        }
    }
    class HandsetBrandM : HandsetBrand
    {
        public override void Run()
        {
            soft.Run();
        }
    }
    //如果是要增加S品牌，只需要增加一个品牌子类就可以了。
    //个数也是一个，不会影响其他类的改动。符合开放封闭原则
    class HandsetBrandS : HandsetBrand
    {
        public override void Run()
        {
            soft.Run();
        }
    }
}
