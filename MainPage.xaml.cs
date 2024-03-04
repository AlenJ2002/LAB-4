using System;
using Microsoft.Maui.Controls;

namespace CalculatorApp
{
    public partial class MainPage : ContentPage // Change from ContentPage to Maui.Controls.ContentPage
    {
        private double _currentValue = 0; // Store the first value of the operation
        private string _currentOperator = ""; // Store the operator selected
        private bool _operatorSelected = false; // Store if an operator was selected

        public MainPage() // Change from MainPage to CalculatorPage
        {
            InitializeComponent(); // Call the InitializeComponent method
        }

        [Obsolete] // 
        private void ShowButtonPressEffect(Button button) // Add the Obsolete attribute
        {
            var originalColor = button.BackgroundColor; // Store the original color
            button.BackgroundColor = Color.FromArgb("white"); // Change the color to white
            Device.StartTimer(TimeSpan.FromMilliseconds(100), () => // Start a timer to change the color back
            {
                button.BackgroundColor = originalColor;// Restore the original color
                return false; // Stop the timer
            });
        }

        [Obsolete]
        private void OnSelectNumber(object sender, EventArgs e) // Add the Obsolete attribute
        {
            var button = (Button)sender; // Cast the sender to a Button
            ShowButtonPressEffect(button);  // Call the ShowButtonPressEffect method

            if (CalculatorDisplay.Text == "0" || _operatorSelected) // Check if the display is 0 or if an operator was selected
            {
                CalculatorDisplay.Text = button.Text; // Set the display to the button's text
                _operatorSelected = false; // Reset the operator selected flag
            }
            else
            {
                CalculatorDisplay.Text += button.Text;  // Append the button's text to the display
            }
        }

        [Obsolete]
        private void OnSelectOperator(object sender, EventArgs e)   // Add the Obsolete attribute
        {
            var button = (Button)sender;
            ShowButtonPressEffect(button);
            _currentValue = double.Parse(CalculatorDisplay.Text); // Store the current value
            _currentOperator = button.Text; //  Store the current operator
            _operatorSelected = true; // Set the operator selected flag
        }

        [Obsolete]
        private void OnCalculate(object sender, EventArgs e)
        {
            var button = (Button)sender;
            ShowButtonPressEffect(button);

            double secondValue = double.Parse(CalculatorDisplay.Text); // Get the second value
            double result = 0; // Store the result  

            switch (_currentOperator) // Perform the operation based on the operator selected
            {
                case "+":
                    result = _currentValue + secondValue; // Perform the addition
                    break;
                case "-":
                    result = _currentValue - secondValue; //    Perform the subtraction
                    break;
                case "x":
                    result = _currentValue * secondValue; // Perform the multiplication
                    break;
                case "÷":
                    if (secondValue != 0) result = _currentValue / secondValue; // Perform the division
                    else
                    {
                        CalculatorDisplay.Text = "Error"; // Display an error message
                        return;
                    }
                    break;
            }

            CalculatorDisplay.Text = result.ToString(); // Display the result
            _currentValue = result; // Set the result as the next operation's first value
            _operatorSelected = false; // Ready for a new operation
        }

        [Obsolete]
        private void OnClear(object sender, EventArgs e) // Add the Obsolete attribute
        {
            var button = (Button)sender; // Cast the sender to a Button
            ShowButtonPressEffect(button);

            CalculatorDisplay.Text = "0"; // Reset the display
            _currentValue = 0; // Reset the first value
            _currentOperator = ""; // Reset the operator
            _operatorSelected = false; //  Reset the operator selected flag
        }

        [Obsolete]
        private void OnToggleSign(object sender, EventArgs e) // Add the Obsolete attribute 
        {
            var button = (Button)sender;
            ShowButtonPressEffect(button);

            if (CalculatorDisplay.Text.StartsWith("-")) // Check if the display is negative
            {
                CalculatorDisplay.Text = CalculatorDisplay.Text.Substring(1); // Remove the negative sign
            }
            else if (!CalculatorDisplay.Text.Equals("0")) // Check if the display is not 0
            {
                CalculatorDisplay.Text = "-" + CalculatorDisplay.Text; // Add a negative sign
            }
        }

        [Obsolete]       
        private void OnPercentage(object sender, EventArgs e) 
        {
            var button = (Button)sender;
            ShowButtonPressEffect(button);

            double currentValue = double.Parse(CalculatorDisplay.Text); // Get the current value
            currentValue /= 100; // Calculate the percentage
            CalculatorDisplay.Text = currentValue.ToString(); // Display the result
        }

        [Obsolete]
        private void OnSelectDecimal(object sender, EventArgs e)    // Add the Obsolete attribute
        {
            var button = (Button)sender;    // Cast the sender to a Button
            ShowButtonPressEffect(button); // Call the ShowButtonPressEffect method

            if (!_operatorSelected && !CalculatorDisplay.Text.Contains(".")) // Check if an operator was not selected and if the display does not contain a decimal
            {
                CalculatorDisplay.Text += "."; // Add a decimal
            }
        }
    }
}
