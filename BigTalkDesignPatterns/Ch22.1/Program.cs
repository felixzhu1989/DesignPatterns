using System;

namespace Ch22._1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            HandsetNGame game = new HandsetNGame();
            game.Run();
            */
            HandsetBrand ab;
            ab = new HandsetBrandMAddressList();
            ab.Run();
            ab = new HandsetBrandNAddressList();
            ab.Run();
            ab = new HandsetBrandMGame();
            ab.Run();
            ab = new HandsetBrandNGame();
            ab.Run();
        }
    }
    /*
    //抽象手机游戏
    class HandsetGame
    {
        public virtual void Run() { }
    }
    //如果我现在有一个N品牌的手机，它有一个小游戏，我要玩游戏，程序应该如何写？
    class HandsetNGame: HandsetGame
    {
        public void Run()
        {
            Console.WriteLine("运行N品牌手机游戏");
        }
    }
    //现在又有一个M品牌的手机，也有小游戏，客户端也可以调用，如何做？
    class HandsetMGame : HandsetGame
    {
        public void Run()
        {
            Console.WriteLine("运行M品牌手机游戏");
        }
    }
    */
    //由于手机都需要通讯录功能，于是N品牌和M品牌都增加了通讯录的增删改查功能。你如何处理？
    //手机品牌
    class HandsetBrand
    {
        public virtual void Run(){}
    }
    class HandsetBrandM : HandsetBrand { }
    class HandsetBrandN : HandsetBrand { }
    class HandsetBrandMGame : HandsetBrandM
    {
        public override void Run()
        {
            Console.WriteLine("运行M品牌手机游戏");
        }
    }
    class HandsetBrandNGame : HandsetBrandN
    {
        public override void Run()
        {
            Console.WriteLine("运行N品牌手机游戏");
        }
    }
    class HandsetBrandMAddressList : HandsetBrandM
    {
        public override void Run()
        {
            Console.WriteLine("运行M品牌手机通讯录");
        }
    }
    class HandsetBrandNAddressList : HandsetBrandN
    {
        public override void Run()
        {
            Console.WriteLine("运行N品牌手机通讯录");
        }
    }
    //如果我现在需要每个品牌都增加一个MP3音乐播放功能，你如何做？
    //又来了一家新的手机品牌‘S’，它也有游戏、通讯录、MP3音乐播放功能，你如何处理？
    //这好像有点麻烦了。
}
