using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ch02._4
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cbxType.ItemsSource = new List<string> { "正常收费", "打八折", "打七折", "打五折", "满300返100" };
            cbxType.SelectedIndex = 0;
        }
        private double total = 0.00d;
        private void BtnOk_OnClick(object sender, RoutedEventArgs e)
        {
            //在客户端去判断用哪一个算法？有没有什么好办法，把这个判断的过程从客户端程序转移走呢？
            //简单工厂就一定要是一个单独的类吗？难道不可以与策略模式的Context结合？
            /*
            CashContext cc = null;
            switch (cbxType.SelectionBoxItem.ToString())
            {
                case "正常收费":
                    cc = new CashContext(new CashNormal());
                    break;
                case "打八折":
                    cc = new CashContext(new CashRebate("0.8"));
                    break;
                case "打七折":
                    cc = new CashContext(new CashRebate("0.7"));
                    break;
                case "打五折":
                    cc = new CashContext(new CashRebate("0.5"));
                    break;
                case "满300返100":
                    cc = new CashContext(new CashReturn("300","100"));
                    break;
            }
            */
            CashContext cc = new CashContext(cbxType.SelectionBoxItem.ToString());
            double totalPrice = 0.00d;
            totalPrice = cc.GetResult(Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtNum.Text));
            total = total + totalPrice;
            lbxList.Items.Add($"Price:{txtPrice.Text},Number:{txtNum.Text},SubTotal:{totalPrice}");
            txtTotal.Text = total.ToString();
        }

        private void BtnReset_OnClick(object sender, RoutedEventArgs e)
        {
            txtPrice.Text = "";
            txtNum.Text = "";
            lbxList.Items.Clear();
            txtTotal.Text = "0.00";
        }
    }
    //CashContext类
    public class CashContext
    {
        /*
        private CashSuper cs;
        public CashContext(CashSuper cs)
        {
            this.cs = cs;
        }
        */
        //简单工厂与策略模式的Context结合
        private CashSuper cs=null;
        public CashContext(string type)
        {
            switch (type)
            {
                case "正常收费":
                    cs = new CashNormal();
                    break;
                case "打八折":
                    cs = new CashRebate("0.8");
                    break;
                case "打七折":
                    cs = new CashRebate("0.7");
                    break;
                case "打五折":
                    cs = new CashRebate("0.5");
                    break;
                case "满300返100":
                    cs = new CashReturn("300", "100");
                    break;
            }
        }
        public double GetResult(double money)
        {
            return cs.AcceptCash(money);
        }
    }
    public abstract class CashSuper
    {
        public abstract double AcceptCash(double money);//参数为原价，返回当前价格
    }

    public class CashNormal : CashSuper
    {
        public override double AcceptCash(double money)
        {
            return money;
        }
    }
    /// <summary>
    /// 打折收费
    /// </summary>
    public class CashRebate : CashSuper
    {
        private double moneyRebate = 1d;
        //初始化必须输入折扣率
        public CashRebate(string moneyRebate)
        {
            this.moneyRebate = Convert.ToDouble(moneyRebate);
        }
        public override double AcceptCash(double money)
        {
            return money * moneyRebate;
        }
    }
    /// <summary>
    /// 返利收费
    /// </summary>
    public class CashReturn : CashSuper
    {
        private double moneyCondition = 0.00d;
        private double moneyReturn = 0.00d;
        //初始化必须输入返利条件
        public CashReturn(string moneyCondition, string moneyReturn)
        {
            this.moneyCondition = Convert.ToDouble(moneyCondition);
            this.moneyReturn = Convert.ToDouble(moneyReturn);
        }
        public override double AcceptCash(double money)
        {
            double result = money;
            if (money >= moneyCondition)
            {
                result = money - Math.Floor(money / moneyCondition) * moneyReturn;
            }
            return result;
        }
    }
}
