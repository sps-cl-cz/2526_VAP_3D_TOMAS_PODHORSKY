using System;
using System.Data;
using Microsoft.Maui.Controls;

namespace MauiCalculator
{
    public partial class MainPage : ContentPage
    {
        private string expression = "0";

        public string Expression
        {
            get
            {
                return expression;
            }
            set
            {
                expression = value;
                OnPropertyChanged(nameof(Expression));
            }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void OnNumberClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                string value = button.Text;

                if (value == "C")
                {
                    Expression = "0";
                }
                else if (value == "=")
                {
                    try
                    {
                        DataTable table = new DataTable();
                        object resultObject = table.Compute(Expression, null);
                        string resultString = Convert.ToString(resultObject);

                        Expression = resultString;
                    }
                    catch (Exception)
                    {
                        Expression = "err";
                    }
                }
                else
                {
                    if (Expression == "0" || Expression == "err")
                    {
                        Expression = value;
                    }
                    else
                    {
                        Expression += value;
                    }
                }
            }
        }

    }
}
        
    

