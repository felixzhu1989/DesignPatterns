using System;

namespace Ch18._1
{
    class Program
    {
        static void Main(string[] args)
        {
            //大战Boss前
            GameRole gr = new GameRole();
            gr.GetInitState();
            gr.StateDisplay();
            //保存进度，暴露了实现细节，不可取
            GameRole backup = new GameRole();
            backup.Vitality = gr.Vitality;
            backup.Attack = gr.Attack;
            backup.Defense = gr.Defense;
            //大战Boss时，损耗严重
            gr.Fight();
            gr.StateDisplay();
            //恢复之前的状态
            gr.Vitality = backup.Vitality;
            gr.Attack = backup.Attack;
            gr.Defense = backup.Defense;
            gr.StateDisplay();
            Console.ReadKey();
        }
    }
    //游戏角色类，用来存储角色的生命力、攻击力、防御力的数据。
    class GameRole
    {
        public int Vitality { get; set; }//生命力
        public int Attack { get; set; }//攻击力
        public int Defense { get; set; }//防御力
        //状态显示
        public void StateDisplay()
        {
            Console.WriteLine("角色当前状态：");
            Console.WriteLine($"体力：{Vitality}");
            Console.WriteLine($"攻击力：{Attack}");
            Console.WriteLine($"防御力：{Defense}");
        }
        //获得初始状态
        public void GetInitState()
        {
            //数据通常来自本机磁盘或远程数据
            Vitality = 100;
            Attack = 100;
            Defense = 100;
        }
        //战斗，与Boss激战后数据损耗为0
        public void Fight()
        {
            Vitality = 0;
            Attack = 0;
            Defense = 0;
        }
    }
}
