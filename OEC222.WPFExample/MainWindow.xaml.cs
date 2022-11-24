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

namespace OEC222.WPFExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            btn.Click += BtnClick;
            btn.Click += BtnClick1;
            btn.MouseMove += (s, e) =>
            {
                txt1.Text = new Random().Next().ToString();
            };
        }

        private void BtnClick(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            var value = rnd.Next();
            txt.Text = value.ToString();
            btn.Click -= BtnClick;
        }

        private void BtnClick1(object sender, RoutedEventArgs e)
        {
            txt1.Text = (1000 * (new Random().Next())).ToString("E3");
        }
    }
}
