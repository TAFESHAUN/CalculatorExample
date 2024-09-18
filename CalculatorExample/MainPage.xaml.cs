namespace CalculatorExample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ResultLabel.Text = "";
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            double number1, number2;
            string operator1 = OperatorEntry1.Text?.Trim();
            string operator2 = OperatorEntry2.Text?.Trim();

            // Validate input numbers
            if (!double.TryParse(FirstNumberEntry.Text, out number1))
            {
                DisplayAlert("Error", "Please enter a valid first number.", "OK");
                return;
            }

            if (!double.TryParse(SecondNumberEntry.Text, out number2))
            {
                DisplayAlert("Error", "Please enter a valid second number.", "OK");
                return;
            }

            // Validate operators
            if (string.IsNullOrEmpty(operator1) && string.IsNullOrEmpty(operator2))
            {
                DisplayAlert("Error", "Please enter an operator (+, -, *, /) in one of the operator entries.", "OK");
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
                        DisplayAlert("Error", "Invalid operator. Please enter +, -, *, or /.", "OK");
                        return;
                }

                ResultLabel.Text = result.ToString();
            }
            catch (DivideByZeroException)
            {
                DisplayAlert("Error", "Cannot divide by zero.", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }
    }

}
