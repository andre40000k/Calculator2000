using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonNum_Click(object sender, RoutedEventArgs e)
        {
            Table.Text = (sender as Button).Content.ToString();
        }

        private void ButtonEquels_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDegree_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonClearC_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Calc_KeyPress(object sender, KeyEventArgs e)
        {
            var key = e.Key;

            switch (key)
            {
                case var k when (k >= Key.D0 && k <= Key.D9) || (k >= Key.NumPad0 && k <= Key.NumPad9):
                    Table.Text = k >= Key.D0 && k <= Key.D9 ? (k - Key.D0).ToString() : (k - Key.NumPad0).ToString();
                    break;
                case Key.Add:
                    Table.Text = ((int)key).ToString();
                    break;
                default:
                    break;

            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}