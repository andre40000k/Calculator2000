using Calculator.Interfaces;
using Calculator.MathOperation;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICalculate _calculate;
        private bool _isShowResult = true;
        private double? _memory;
        private double? _number1;
        private double? _number2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Culculate()
        {
            if (_isShowResult)
            {
                return;
            }
            if (_number1 == null || _calculate == null)
            {
                _number1 = double.Parse(Table.Text);
                Table.Text = _number1.ToString();
                _isShowResult = true;
            }
            else if (_number2 == null && _calculate != null)
            {
                _number2 = double.Parse(Table.Text);
                try
                {
                    _number1 = _calculate.Calculate(_number1.Value, _number2.Value);
                    _calculate = null;
                }
                catch (DivideByZeroException ex)
                {
                    MessageBox.Show("Делить на 0 нельзя!", "Ошибка!");
                    ButtonClearC_Click(null, null);
                    return;
                }
                Table.Text = _number1.ToString();
                _isShowResult = true;
                _number2 = null;
            }
        }


        private void ButtonNum_Click(object sender, RoutedEventArgs e)
        {
            CheckCharecters((sender as Button).Content.ToString());
        }

        private void ButtonEquels_Click(object sender, RoutedEventArgs e)
        {
            Culculate();
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            Culculate();
            _calculate = new Plus();
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            Culculate();
            _calculate = new Minus();
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            Culculate();
            _calculate = new Multiply();
        }

        private void ButtonDegree_Click(object sender, RoutedEventArgs e)
        {
            Culculate();
            _calculate = new Degree();
        }

        private void ButtonClearC_Click(object sender, RoutedEventArgs e)
        {
            _isShowResult = true;
            _number1 = null;
            _number2 = null;
            Table.Text = "0";
        }

        private void Calc_KeyPress(object sender, KeyEventArgs e)
        {
            //Table.Text = e.Key.ToString();

            switch (e.Key)
            {
                case var k when (k >= Key.D0 && k <= Key.D9) || (k >= Key.NumPad0 && k <= Key.NumPad9):
                    var symbol = k >= Key.D0 && k <= Key.D9 ? (k - Key.D0).ToString() : (k - Key.NumPad0).ToString();
                    CheckCharecters(symbol);
                    break;
                case var op when op == Key.OemMinus || op == Key.Subtract:
                    Culculate();
                    _calculate = new Minus();
                    break;
                case var op when op == Key.OemPlus || op == Key.Add:
                    Culculate();
                    _calculate = new Plus();
                    break;
                case var op when op == Key.Multiply:
                    Culculate();
                    _calculate = new Multiply();
                    break;
                case var op when op == Key.Divide:
                    Culculate();
                    _calculate = new Degree();
                    break;
                case var op when op == Key.Return || op == Key.Enter:
                    Culculate();
                    break;
                case var op when op == Key.OemComma || op == Key.OemPeriod || op == Key.Decimal:
                    CheckCharecters(op);
                    break;
                case var k when k == Key.Back:
                    RemoveCharecters();
                    break;
                default:
                    break;
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            RemoveCharecters();
        }

        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            if (_isShowResult)
            {
                ButtonClearC_Click(sender, e);
                _isShowResult = false;
            }
            ButtonNum_Click(sender, e);
        }

        private void RemoveCharecters()
        {
            if (!_isShowResult && Table.Text.Length != 0)
            {
                var TText = new StringBuilder(Table.Text);
                TText.Remove(TText.Length - 1, 1);
                Table.Text = TText.ToString();
            }
            if (!_isShowResult && Table.Text.Length == 0)
            {
                Table.Text = "0";
                _isShowResult = true;
            }
        }

        private void CheckCharecters<T>(T charecter)
        {
            if (_isShowResult)
            {
                _isShowResult = false;
                Table.Text = "";
            }
            if(charecter is Key key)
            {
                if (key == Key.OemComma || key == Key.OemPeriod || key == Key.Decimal)
                {
                    if (Table.Text.Contains(",") == false || Table.Text.Contains(".") == false)
                        Table.Text += ",";
                }
                else
                {
                    Table.Text += charecter;
                }
            }
            if (charecter is string simbol)
            {
                if (simbol == ",")
                {
                    if (Table.Text.Contains(",") == false)
                        Table.Text += ",";
                }
                else
                {
                    Table.Text += charecter;
                }
            }
            
        }
    }
}