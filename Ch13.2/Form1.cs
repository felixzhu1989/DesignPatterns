using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ch13._2
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
            ptb.Build();
        }

        private void btnBuildFat_Click(object sender, EventArgs e)
        {
            Pen p = new Pen(Color.OrangeRed);
            Graphics gFat = pictureBox1.CreateGraphics();
            PersonFatBuilder pfb = new PersonFatBuilder(gFat, p);
            pfb.Build();
        }
    }

    class PersonThinBuilder
    {
        private Graphics g;
        private Pen p;
        //初始化确定画板和颜色
        public PersonThinBuilder(Graphics g,Pen p)
        {
            this.g = g;
            this.p = p;
        }
        public void Build()
        {
            g.Clear(Color.White);
            g.DrawEllipse(p, 50, 20, 30, 30);//头
            g.DrawRectangle(p, 60, 50, 10, 50);//身体
            g.DrawLine(p, 60, 50, 40, 100);//左手
            g.DrawLine(p, 70, 50, 90, 100);//右手
            g.DrawLine(p, 60, 100, 45, 150);//左脚
            g.DrawLine(p, 70, 100, 85, 150);//右脚
        }
    }
    class PersonFatBuilder
    {
        private Graphics g;
        private Pen p;
        public PersonFatBuilder(Graphics g, Pen p)
        {
            this.g = g;
            this.p = p;
        }
        public void Build()
        {
            g.Clear(Color.White);
            g.DrawEllipse(p, 50, 20, 30, 30);//头
            g.DrawEllipse(p, 45, 50, 40, 50);//身体
            g.DrawLine(p, 50, 50, 30, 100);//左手
            g.DrawLine(p, 80, 50, 100, 100);//右手
            g.DrawLine(p, 60, 100, 45, 150);//左脚
            g.DrawLine(p, 70, 100, 85, 150);//右脚
        }
    }
}
