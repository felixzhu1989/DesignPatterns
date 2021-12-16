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

namespace Ch02._1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private double total = 0.00d;
        private void BtnOk_OnClick(object sender, RoutedEventArgs e)
        {
            double totalPrice = Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtNum.Text);
            total = total + totalPrice;
            lbxList.Items.Add($"Price:{txtPrice.Text},Number:{txtNum.Text},SubTotal:{totalPrice}");
            txtTotal.Text = total.ToString();
        }

        private void BtnReset_OnClick(object sender, RoutedEventArgs e)
        {
            txtPrice.Text="";
            txtNum.Text = "";
            lbxList.Items.Clear();
            txtTotal.Text = "0.00";
        }
    }
}
