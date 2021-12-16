using System;
using System.Collections.Generic;
using System.Windows;

namespace Ch02._2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cbxType.ItemsSource = new List<string>{ "正常收费", "打八折", "打七折", "打五折" };
            cbxType.SelectedIndex = 0;
        }
        private double total = 0.00d;
        private void BtnOk_OnClick(object sender, RoutedEventArgs e)
        {
            //重复代码很多，像Convert.ToDouble()，你这里就写了8遍,需要重构
            double totalPrice = 0.00d;
            switch (cbxType.SelectedIndex)
            {
                case 0:
                    totalPrice = Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtNum.Text);
                    break;
                case 1:
                    totalPrice = Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtNum.Text)*0.8;
                    break;
                case 2:
                    totalPrice = Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtNum.Text)*0.7;
                    break;
                case 3:
                    totalPrice = Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtNum.Text)*0.5;
                    break;
            }
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
}
