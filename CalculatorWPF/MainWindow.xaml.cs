using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ResultLabel.Content = "";
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double number1, number2;
            string operator1 = OperatorTextBox1.Text.Trim();
            string operator2 = OperatorTextBox2.Text.Trim();

            // Validate input numbers
            if (!double.TryParse(FirstNumberTextBox.Text, out number1))
            {
                MessageBox.Show("Please enter a valid first number.");
                return;
            }

            if (!double.TryParse(SecondNumberTextBox.Text, out number2))
            {
                MessageBox.Show("Please enter a valid second number.");
                return;
            }

            // Validate operators
            if (string.IsNullOrEmpty(operator1) && string.IsNullOrEmpty(operator2))
            {
                MessageBox.Show("Please enter an operator (+, -, *, /) in one of the operator text boxes.");
                return;
            }

            string selectedOperator = !string.IsNullOrEmpty(operator1) ? operator1 : operator2;

            double result = 0;
            try
            {
                switch (selectedOperator)
                {
                    case "+":
                        result = number1 + number2;
                        break;
                    case "-":
                        result = number1 - number2;
                        break;
                    case "*":
                        result = number1 * number2;
                        break;
                    case "/":
                        if (number2 == 0)
                            throw new DivideByZeroException();
                        result = number1 / number2;
                        break;
                    default:
                        MessageBox.Show("Invalid operator. Please enter +, -, *, or /.");
                        return;
                }

                ResultLabel.Content = result.ToString();
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Cannot divide by zero.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}