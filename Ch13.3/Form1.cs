using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ch13._3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnBuildThin_Click(object sender, EventArgs e)
        {
            Pen p = new Pen(Color.DarkCyan);
            Graphics gThin = pictureBox1.CreateGraphics();
            PersonThinBuilder ptb = new PersonThinBuilder(gThin, p);
            PersonDirector pdThin = new PersonDirector(ptb);
            pdThin.CreatePerson();
        }
        private void btnBuildFat_Click(object sender, EventArgs e)
        {
            Pen p = new Pen(Color.OrangeRed);
            Graphics gFat = pictureBox1.CreateGraphics();
            PersonFatBuilder pfb = new PersonFatBuilder(gFat, p);
            PersonDirector pdThin = new PersonDirector(pfb);
            pdThin.CreatePerson();
        }
    }
    //先定义一个抽象的建造人的类，来把这个过程给稳定住，不让任何人遗忘当中的任何一步。
    abstract class PersonBuilder
    {
        protected Graphics g;
        protected Pen p;
        public PersonBuilder(Graphics g, Pen p)
        {
            this.g = g;
            this.p = p;
            g.Clear(Color.White);
        }
        public abstract void BuildHead();
        public abstract void BuildBody();
        public abstract void BuildArmLeft();
        public abstract void BuildArmRight();
        public abstract void BuildLegLeft();
        public abstract void BuildLegRight();
    }
    //我们需要建造一个瘦的小人，则让这个瘦子类去继承这个抽象类，那就必须去重写这些抽象方法了。否则编译器也不让你通过。
    class PersonThinBuilder:PersonBuilder
    {
        public PersonThinBuilder(Graphics g, Pen p) : base(g, p)
        {
        }
        public override void BuildHead()
        {
            g.DrawEllipse(p, 50, 20, 30, 30);//头
        }
        public override void BuildBody()
        {
            g.DrawRectangle(p, 60, 50, 10, 50);//身体
        }
        public override void BuildArmLeft()
        {
            g.DrawLine(p, 60, 50, 40, 100);//左手
        }
        public override void BuildArmRight()
        {
            g.DrawLine(p, 70, 50, 90, 100);//右手
        }
        public override void BuildLegLeft()
        {
            g.DrawLine(p, 60, 100, 45, 150);//左脚
        }
        public override void BuildLegRight()
        {
            g.DrawLine(p, 70, 100, 85, 150);//右脚
        }
    }

    class PersonFatBuilder : PersonBuilder
    {
        public PersonFatBuilder(Graphics g, Pen p) : base(g, p)
        {
        }

        public override void BuildHead()
        {
            g.DrawEllipse(p, 50, 20, 30, 30);//头
        }

        public override void BuildBody()
        {
            g.DrawEllipse(p, 45, 50, 40, 50);//身体
        }

        public override void BuildArmLeft()
        {
            g.DrawLine(p, 50, 50, 30, 100);//左手
        }

        public override void BuildArmRight()
        {
            g.DrawLine(p, 80, 50, 100, 100);//右手
        }

        public override void BuildLegLeft()
        {
            g.DrawLine(p, 60, 100, 45, 150);//左脚
        }

        public override void BuildLegRight()
        {
            g.DrawLine(p, 70, 100, 85, 150);//右脚
        }
    }
    //指挥者（Director），用它来控制建造过程，也用它来隔离用户与建造过程的关联。
    class PersonDirector
    {
        private PersonBuilder pb;
        //告诉指挥者，我们需要什么样的小人
        public PersonDirector(PersonBuilder pb)
        {
            this.pb = pb;
        }
        //根据用户的选择pb，创造小人
        public void CreatePerson()
        {
            pb.BuildHead();
            pb.BuildBody();
            pb.BuildArmLeft();
            pb.BuildArmRight();
            pb.BuildLegLeft();
            pb.BuildLegRight();
        }
    }
}
