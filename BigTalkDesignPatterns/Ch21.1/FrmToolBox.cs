using System.Windows.Forms;

namespace Ch21._1
{
    public partial class FrmToolBox : Form
    {
        private static FrmToolBox ftb = null;//声明一个静态变量
        //私有化构造方法，代码不能直接new来实例化
        private FrmToolBox()
        {
            InitializeComponent();
        }
        //静态方法，返回本类的对象
        public static FrmToolBox GetFrmToolBoxInstance()
        {
            if (ftb == null || ftb.IsDisposed)
            {
                ftb = new FrmToolBox();
                ftb.MdiParent = FrmMain.ActiveForm;
            }
            return ftb;
        }
    }
}
