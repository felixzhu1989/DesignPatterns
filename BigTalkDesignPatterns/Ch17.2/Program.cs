using System;

namespace Ch17._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Player b = new Forwards("巴蒂尔");
            b.Attack();
            Player m = new Guards("麦克雷蒂");
            m.Attack();
            //翻译告诉姚明，教练要求你进攻和防守
            Player ym = new Translator("姚明");
            ym.Attack();
            ym.Defense();
            Console.ReadKey();
        }
    }
    abstract class Player
    {
        protected string name;
        public Player(string name)
        {
            this.name = name;
        }
        public abstract void Attack();
        public abstract void Defense();
    }
    //前锋
    class Forwards:Player
    {
        public Forwards(string name) : base(name)
        {
        }
        public override void Attack()
        {
            Console.WriteLine($"前锋{name}进攻");
        }
        public override void Defense()
        {
            Console.WriteLine($"前锋{name}防守");
        }
    }
    //中锋
    class Center : Player
    {
        public Center(string name) : base(name)
        {
        }
        public override void Attack()
        {
            Console.WriteLine($"中锋{name}进攻");
        }
        public override void Defense()
        {
            Console.WriteLine($"中锋{name}防守");
        }
    }
    //外籍中锋
    class ForeignCenter
    {
        public string Name { get; set; }
        public  void ForeignAttack()
        {
            Console.WriteLine($"外籍中锋{Name}进攻");
        }
        public  void ForeignDefense()
        {
            Console.WriteLine($"外籍中锋{Name}防守");
        }
    }
    //翻译
    class Translator:Player
    {
        //声明并实例化一个内部外籍中锋对象，表明翻译者与外籍球员有关联
        private ForeignCenter wjzf = new ForeignCenter();
        public Translator(string name) : base(name)
        {
            wjzf.Name = name;
        }
        public override void Attack()
        {
            wjzf.ForeignAttack();
        }
        public override void Defense()
        {
            wjzf.ForeignDefense();
        }
    }
    //后卫
    class Guards : Player
    {
        public Guards(string name) : base(name)
        {
        }
        public override void Attack()
        {
            Console.WriteLine($"后卫{name}进攻");
        }
        public override void Defense()
        {
            Console.WriteLine($"后卫{name}防守");
        }
    }
}
