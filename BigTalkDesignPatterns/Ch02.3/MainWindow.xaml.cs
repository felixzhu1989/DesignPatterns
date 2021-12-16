using System;
using System.Collections.Generic;
using System.Windows;

namespace Ch02._3
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cbxType.ItemsSource = new List<string> { "正常收费", "打八折", "打七折", "打五折","满300返100" };
            cbxType.SelectedIndex = 0;
        }
        private double total = 0.00d;
        private void BtnOk_OnClick(object sender, RoutedEventArgs e)
        {
            CashSuper cashSuper = CashFactory.CreateCashAccept(cbxType.SelectedItem.ToString());
            double totalPrice = 0.00d;
            totalPrice = cashSuper.AcceptCash(Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtNum.Text));
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
    /// <summary>
    /// 现金收费工厂类
    /// </summary>
    public class CashFactory
    {
        public static CashSuper CreateCashAccept(string type)
        {
            CashSuper cs = null;
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
            return cs;
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
            return money* moneyRebate;
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
        public CashReturn(string moneyCondition,string moneyReturn)
        {
            this.moneyCondition = Convert.ToDouble(moneyCondition);
            this.moneyReturn = Convert.ToDouble(moneyReturn);
        }
        public override double AcceptCash(double money)
        {
            double result=money;
            if (money >= moneyCondition)
            {
                result = money - Math.Floor(money / moneyCondition) * moneyReturn;
            }
            return result;
        }
    }
}
