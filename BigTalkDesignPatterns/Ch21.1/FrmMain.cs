using System;
using System.Windows.Forms;

namespace Ch21._1
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        private FrmToolBox ftb;//将窗口作为全局变量，判断对象是否是null
        private void tsmiToolBox_Click(object sender, EventArgs e)
        {
            //OpenToolBox();
            //单例模式
            FrmToolBox.GetFrmToolBoxInstance().Show();
        }

        private void tsbToolBox_Click(object sender, EventArgs e)
        {
            //复制粘贴是最容易的编程，但也是最没有价值的编程。
            /*
            if (ftb == null || ftb.IsDisposed)
            {
                ftb = new FrmToolBox();
                ftb.MdiParent = this;
                ftb.Show();
            }
            */
            //提炼出一个方法来让他们调用。
            //OpenToolBox();
            FrmToolBox.GetFrmToolBoxInstance().Show();
        }
        /*
        private void OpenToolBox()
        {
            if (ftb == null || ftb.IsDisposed)
            {
                ftb = new FrmToolBox();
                ftb.MdiParent = this;
                ftb.Show();
            }
        }
        */
        /* 领导问下属，报告交了没有，下属可能说‘早交了’于是领导满意地点点头，
         * 下属也可能说‘还剩下一点内容没写，很快上交’，领导皱起眉头说‘要抓紧’。
         * 此时这份报告交还是没交，由谁来判断？
         * 当然是下属自己的判断，因为下属最清楚报告交了没有，领导只需要问问就行了。
         * Form1里应该只是通知启动‘工具箱’，至于‘工具箱’窗体是否实例化过，应该由‘工具箱’自己来判断？
         */
    }
}
