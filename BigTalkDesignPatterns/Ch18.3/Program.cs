using System;

namespace Ch18._3
{
    class Program
    {
        static void Main(string[] args)
        {
            //大战Boss前
            GameRole gr = new GameRole();
            gr.GetInitState();
            gr.StateDisplay();
            //保存进度
            RoleStateCaretaker stateAdmin = new RoleStateCaretaker();
            stateAdmin.Memento = gr.SaveState();
            GameRole backup = new GameRole();
            //大战Boss时，损耗严重
            gr.Fight();
            gr.StateDisplay();
            //恢复之前的状态
            gr.RecoverState(stateAdmin.Memento);
            gr.StateDisplay();
            Console.ReadKey();
        }
    }
    class RoleStateMemento
    {
        public int Vitality { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public RoleStateMemento(int vit,int atk,int def)
        {
            Vitality = vit;
            Attack = atk;
            Defense = def;
        }
    }
    class RoleStateCaretaker
    {
        public RoleStateMemento Memento { get; set; }
    }
    class GameRole
    {
        public int Vitality { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public void StateDisplay()
        {
            Console.WriteLine("角色当前状态：");
            Console.WriteLine($"体力：{Vitality}");
            Console.WriteLine($"攻击力：{Attack}");
            Console.WriteLine($"防御力：{Defense}");
        }
        //保存角色状态
        public RoleStateMemento SaveState()
        {
            return new RoleStateMemento(Vitality, Attack, Defense);
        }
        //恢复角色状态
        public void RecoverState(RoleStateMemento memento)
        {
            Vitality = memento.Vitality;
            Attack = memento.Attack;
            Defense = memento.Defense;
        }
        public void GetInitState()
        {
            Vitality = 100;
            Attack = 100;
            Defense = 100;
        }
        public void Fight()
        {
            Vitality = 0;
            Attack = 0;
            Defense = 0;
        }
    }
}
