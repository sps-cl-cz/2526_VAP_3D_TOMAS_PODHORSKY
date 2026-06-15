namespace MauiKalkulacka;

public partial class MainPage : ContentPage
{
    string currentNumber = "";
    double firstNumber = 0;
    string selectedOperator = "";

    public MainPage()
    {
        InitializeComponent();
    }

    void OnNumberClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        currentNumber += button.Text;
        DisplayLabel.Text = currentNumber;
    }

    void OnOperatorClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;

        if (currentNumber != "")
        {
            firstNumber = double.Parse(currentNumber);
            selectedOperator = button.Text;
            currentNumber = "";
        }
    }

    void OnEqualsClicked(object sender, EventArgs e)
    {
        if (currentNumber == "" || selectedOperator == "")
            return;

        double secondNumber = double.Parse(currentNumber);
        double result = 0;

        switch (selectedOperator)
        {
            case "+":
                result = firstNumber + secondNumber;
                break;

            case "−":
                result = firstNumber - secondNumber;
                break;

            case "×":
                result = firstNumber * secondNumber;
                break;

            case "÷":
                if (secondNumber != 0)
                    result = firstNumber / secondNumber;
                else
                {
                    DisplayLabel.Text = "Chyba";
                    return;
                }
                break;
        }

        DisplayLabel.Text = result.ToString();
        currentNumber = result.ToString();
        selectedOperator = "";
    }

    void OnClearClicked(object sender, EventArgs e)
    {
        currentNumber = "";
        firstNumber = 0;
        selectedOperator = "";
        DisplayLabel.Text = "0";
    }
}
