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

namespace Standart_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double result = 0;
        string OperationPerformed = "";
        bool used = false;
        bool IsSwitched = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            used = false;
            Button button = (Button)sender;
            Results.Text = Results.Text + button.Content;

        }
        private void ButtonDecimal_Click(object sender, RoutedEventArgs e)
        {
            if (!Results.Text.Contains(","))
            {
                if (used == true) Results.Text = "";
                Results.Text = Results.Text + ",";

            }
        }
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (IsSwitched == false)
            {

                if (result != 0)
                {
                    ButtonEqual_Click(sender, e);
                    OperationPerformed = (string)button.Content;
                    Indicator.Text = result.ToString() + " " + OperationPerformed;
                    Results.Text = "";
                    used = true;
                }
                else
                {
                    OperationPerformed = (string)button.Content;
                    result = double.Parse(Results.Text);
                    Indicator.Text = result.ToString() + " " + OperationPerformed;
                    Results.Text = "";
                    used = true;
                }
            }
            else
            {
                Results.Text = Results.Text + " " + (string)button.Content + " ";
            }
        }
        private void ButtonEqual_Click(object sender, RoutedEventArgs e)
        {
           
                switch (OperationPerformed)
                {
                    case "+":
                        Results.Text = (result + double.Parse(Results.Text)).ToString();
                        break;
                    case "-":
                        Results.Text = (result - double.Parse(Results.Text)).ToString();
                        break;
                    case "*":
                        Results.Text = (result * double.Parse(Results.Text)).ToString();
                        break;
                    case "/":
                        if (double.Parse(Results.Text) == 0) { Indicator.Text = "INFINITY"; }
                        else Results.Text = (result / double.Parse(Results.Text)).ToString();
                        break;
                }
                if (Indicator.Text == "INFINITY") { Results.Text = ""; }
                else
                {
                    result = double.Parse(Results.Text);
                    Indicator.Text = result.ToString();
                }

        }
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            Results.Text = "";
            Indicator.Text = "";
            result = 0;

        }
        private void ButtonBackspace_Click(object sender, RoutedEventArgs e)
        {
            if (Results.Text.Count() > 0)
            {
                Results.Text = Results.Text.Remove(Results.Text.Length - 1);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D0:
                case Key.NumPad0:
                    Button_Click(Button0, e);
                    break;
                case Key.D1:
                case Key.NumPad1:
                    Button_Click(Button1, e);
                    break;
                case Key.D2:
                case Key.NumPad2:
                    Button_Click(Button2, e);
                    break;
                case Key.D3:
                case Key.NumPad3:
                    Button_Click(Button3, e);
                    break;
                case Key.D4:
                case Key.NumPad4:
                    Button_Click(Button4, e);
                    break;
                case Key.D5:
                case Key.NumPad5:
                    Button_Click(Button5, e);
                    break;
                case Key.D6:
                case Key.NumPad6:
                    Button_Click(Button6, e);
                    break;
                case Key.D7:
                case Key.NumPad7:
                    Button_Click(Button7, e);
                    break;
                case Key.D8:
                case Key.NumPad8:
                    Button_Click(Button8, e);
                    break;
                case Key.D9:
                case Key.NumPad9:
                    Button_Click(Button9, e);
                    break;
                case Key.Add:
                    Operation_Click(ButtonAddition, e);
                    break;
                case Key.Subtract:
                    Operation_Click(ButtonSubtraction, e);
                    break;
                case Key.Multiply:
                    Operation_Click(ButtonMultiplication, e);
                    break;
                case Key.Divide:
                    Operation_Click(ButtonDivision, e);
                    break;
                case Key.OemOpenBrackets:
                    Results.Text = Results.Text + "(";
                    break;
                case Key.OemCloseBrackets:
                    Results.Text = Results.Text + ")";
                    break;
                case Key.Enter:
                    ButtonEqual_Click(sender, e);
                    break;
                case Key.Back:
                    ButtonBackspace_Click(sender, e);
                    break;
                case Key.C:
                    ButtonClear_Click(sender, e);
                    break;
            }

        }
    }
}
