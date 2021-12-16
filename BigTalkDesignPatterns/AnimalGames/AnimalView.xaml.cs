using System;
using System.Collections.Generic;
using System.Windows;

namespace AnimalGames
{
    /// <summary>
    /// Cat.xaml 的交互逻辑
    /// </summary>
    public partial class AnimalView : Window
    {
        public AnimalView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("喵"); //[1]不合理
            //MessageBox.Show(Shout()); //[2]不合理
            Cat cat = new Cat("咪咪");//实例化Cat，在任何需要小猫叫的地方都可以实例化它。
            cat.ShoutNum = 5;//给属性赋值
            MessageBox.Show(cat.Shout());

        }

        /* ‘Shout(猫叫)’放在这个窗体的代码中合适吗？
         * 这就好比，居委会的公用电视放在你家，
         * 而别人家都没有，于是街坊邻居都来你家看电视。 
         */

        //string Shout()
        //{
        //    return "喵";
        //}

        private void BtnDog_OnClick(object sender, RoutedEventArgs e)
        {
            Dog dog = new Dog("旺财");//实例化Cat，在任何需要小猫叫的地方都可以实例化它。
            dog.ShoutNum = 5;//给属性赋值
            MessageBox.Show(dog.Shout());
        }

        //private Animal[] arrayAnimals;
        private IList<Animal> arrayAnimals;
        private void BtnApply_OnClick(object sender, RoutedEventArgs e)
        {
            //arrayAnimals = new Animal[5];//最多5个动物报名参赛
            //arrayAnimals[0] = new Cat("小花");
            //arrayAnimals[1] = new Dog("阿毛");
            //arrayAnimals[2] = new Cat("小白");
            //arrayAnimals[3] = new Dog("旺财");
            //arrayAnimals[4] = new Cat("咪咪");

            arrayAnimals = new List<Animal>();
            //Add的参数必须是要Animal或者Animal的子类型才行。
            arrayAnimals.Add(new Cat("小花"));
            arrayAnimals.Add(new Dog("旺财"));
            arrayAnimals.Add(new Cattle("小牛"));
            arrayAnimals.Add(new Sheep("小羊"));
            arrayAnimals.Add(new Cat("咪咪"));
        }

        private void BtnShoutGame_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var item in arrayAnimals)
            {
                MessageBox.Show(item.Shout());//多态，程序会自动找到Item是什么对象，调用重写的方法
            }
        }

        private void BtnChangeThing_OnClick(object sender, RoutedEventArgs e)
        {
            MachineCat mCat = new MachineCat("叮当");
            MoCattle mCattle = new MoCattle("牛魔王");
            IChange[] array = new IChange[2];
            array[0] = mCat;
            array[1] = mCattle;
            MessageBox.Show(array[0].ChangeThing("各种各样的东西！"));
            MessageBox.Show(array[1].ChangeThing("七十二变！"));
        }

        private void BenEvent_OnClick(object sender, RoutedEventArgs e)
        {
            Cat cat = new Cat("Tom");
            Mouse mouse1 = new Mouse("Jerry");
            Mouse mouse2 = new Mouse("Jack");
            //将Mouse的Run方法，通过实例化委托Cat.CatShoutEventHandler登记到Cat的事件CatShout中
            cat.CatShout += new Cat.CatShoutEventHandler(mouse1.Run);
            cat.CatShout += new Cat.CatShoutEventHandler(mouse2.Run);
            cat.Shout2();
        }
    }
    /* 我们会发现大部分代码都是相同的，所以我们现在建立一个父类，
     * 动物Animal类，显然猫和狗都是动物。我们把相同的代码尽量放到动物类中。
     * Animal类其实根本就不可能实例化的，你想呀，说一只猫长什么样，可以想象，
     * 说newAnimal();即实例化一个动物。一个动物长什么样？
     * 动物是一个抽象的名词，没有具体对象与之对应。
     * 所以我们完全可以考虑把实例化没有任何意义的父类，改成抽象类
     */
    public abstract class Animal
    {
        protected string name = "";//注意修饰符，protected表示继承时子类可以对基类有完全访问权。
        protected Animal(string name)
        {
            this.name = name;
        }
        protected Animal()
        {
            this.name = "无名";
        }
        protected int shoutNum = 3;
        public int ShoutNum
        {
            get => shoutNum;
            set
            {
                if (value <= 10)
                {
                    shoutNum = value;
                }
                else
                {
                    shoutNum = 10;
                }
            }
        }
        //虚方法
        //public virtual string Shout()
        //{
        //    return "";
        //}

        //子类拥有所有父类非private的属性和方法。
        //由于子类继承父类，所以是public的Shout方法是一定可以为所有子类所用的。
        public string Shout()
        {
            string result = "";
            for (int i = 0; i < shoutNum; i++)
            {
                result += $"{GetShoutSound()} ";//进一步封装变化，减少重复代码
            }
            return $"我的名字叫{name}，{result}";
        }
        //对于Animal类的getShoutSound方法，其实方法体没有任何意义，
        //所以可以将virtual修饰符改为abstract，使之成为抽象方法。
        //protected virtual string GetShoutSound()
        //{
        //    return "";
        //}
        protected abstract string GetShoutSound();//没有方法体，必须由子类去实现
    }

    //然后我们需要写Cat和Dog的代码。让它们继承Animal。
    //这里其实就是在用一个设计模式，叫模板方法。
    public class Cat : Animal
    {
        /*
        private string name = "";//私有字段
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="name"></param>
        public Cat(string name)
        {
            this.name = name;//将参数赋值给私有变量name
        }

        public Cat()
        {
            this.name = "无名";
        }
        private int shoutNum=3;//私有的变量，初始值，默认叫三声

        public int ShoutNum
        {
            get => shoutNum;//外界可以得到shoutNum的值
            //外界可以对shoutNum赋值
            set
            {
                //控制叫声次数，最多10次
                if(value<=10)
                {
                    shoutNum = value;
                }
                else
                {
                    shoutNum = 10;
                }
            }
        }
        */
        public Cat() : base()//调用父类同样参数的构造方法
        {
        }
        public Cat(string name) : base(name)
        {
        }
        /*
        public override string Shout()
        {
            string result = "";
            for (int i = 0; i < shoutNum; i++)
            {
                result += "喵 ";
            }
            return $"我的名字叫{name}，{result}";
        }
        */
        protected override string GetShoutSound()
        {
            return "喵";
        }
        //声明了一个委托,委托所能代表的方法是无参数、无返回值的方法。
        //public delegate void CatShoutEventHandler();
        

        //增加两个参数，第一个参数object对象sender是指向发送通知的对象，
        //而第二个参数CatShoutEventArgs的args，包含了所有通知接受者需要附件的信息。
        public delegate void CatShoutEventHandler(object sender,CatShoutEventArgs args);

        //因为事件CatShout的类型是委托CatShoutEventHandler，
        //而CatShoutEventHandler就是无参数、无返回值的。
        //表明事件发生时，执行被委托的方法。
        public event CatShoutEventHandler CatShout;

        public void Shout2()
        {
            MessageBox.Show($"我是{name},{GetShoutSound()}");
            if (CatShout != null)
            {
                CatShoutEventArgs e = new CatShoutEventArgs();
                e.Name = this.name;
                CatShout(this,e);
            }
        }
    }

    public class CatShoutEventArgs:EventArgs
    {
        public string Name { get; set; }
    }
    class Mouse : Animal
    {
        public Mouse() : base()
        {
        }
        public Mouse(string name) : base(name)
        {
        }
        protected override string GetShoutSound()
        {
            return "吱";
        }

        public void Run(object sender,CatShoutEventArgs args)
        {
            MessageBox.Show($"老猫{args.Name}来了，{name}快跑");
        }
    }
    public class Dog : Animal
    {
        /*
        //非常多的重复代码
        private string name = "";
        public Dog(string name)
        {
            this.name = name;
        }
        public Dog()
        {
            this.name = "无名";
        }
        private int shoutNum = 3;

        public int ShoutNum
        {
            get => shoutNum;
            set
            {
                if (value <= 10)
                {
                    shoutNum = value;
                }
                else
                {
                    shoutNum = 10;
                }
            }
        }
        */
        public Dog() : base()
        {
        }
        public Dog(string name) : base(name)
        {
        }
        /*
        public override string Shout()
        {
            string result = "";
            for (int i = 0; i < shoutNum; i++)
            {
                result += "汪 ";
            }
            return $"我的名字叫{name}，{result}";
        }
        */
        protected override string GetShoutSound()
        {
            return "汪";
        }
    }

    class Cattle : Animal
    {
        public Cattle() : base()
        {
        }
        public Cattle(string name) : base(name)
        {
        }
        protected override string GetShoutSound()
        {
            return "哞";
        }
    }
    class Sheep : Animal
    {
        public Sheep() : base()
        {
        }
        public Sheep(string name) : base(name)
        {
        }
        protected override string GetShoutSound()
        {
            return "咩";
        }
    }
    
    interface IChange
    {
        string ChangeThing(string thing);
    }

    class MachineCat : Cat, IChange
    {
        public MachineCat() : base()
        {
        }
        public MachineCat(string name) : base(name)
        {
        }
        //由于继承了猫，所以也会喵喵叫
        public string ChangeThing(string thing)
        {
            return $"{base.Shout()} ，我有万能的口袋，我可以变出{thing}";
        }
    }
    class MoCattle : Cattle, IChange
    {
        public MoCattle() : base()
        {
        }
        public MoCattle(string name) : base(name)
        {
        }
        public string ChangeThing(string thing)
        {
            return $"{base.Shout()} ，我和孙悟空有相同的师承，我也会{thing}";
        }
    }
}
