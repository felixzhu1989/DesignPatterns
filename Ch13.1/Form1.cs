using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ch13._1
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
            gThin.Clear(Color.White);
            gThin.DrawEllipse(p, 50, 20, 30, 30);//头
            gThin.DrawRectangle(p, 60, 50, 10, 50);//身体
            gThin.DrawLine(p, 60, 50, 40, 100);//左手
            gThin.DrawLine(p, 70, 50, 90, 100);//右手
            gThin.DrawLine(p, 60, 100, 45, 150);//左脚
            gThin.DrawLine(p, 70, 100, 85, 150);//右脚
        }

        private void btnBuildFat_Click(object sender, EventArgs e)
        {
            Pen p = new Pen(Color.OrangeRed);
            Graphics gFat = pictureBox1.CreateGraphics();
            gFat.Clear(Color.White);
            gFat.DrawEllipse(p, 50, 20, 30, 30);//头
            gFat.DrawEllipse(p, 45, 50, 40, 50);//身体
            gFat.DrawLine(p, 50, 50, 30, 100);//左手
            gFat.DrawLine(p, 80, 50, 100, 100);//右手
            gFat.DrawLine(p, 60, 100, 45, 150);//左脚
            gFat.DrawLine(p, 70, 100, 85, 150);//右脚
        }
    }
}
