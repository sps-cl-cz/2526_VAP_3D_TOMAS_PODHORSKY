using System;
using System.Data;
using Microsoft.Maui.Controls;

namespace MauiCalculator
{
    public partial class MainPage : ContentPage
    {
        private bool _lightTheme = true;
        public bool LightTheme 
        {
            get => _lightTheme;
            set
            {
                _lightTheme = value;
                App.Current.UserAppTheme = value ? AppTheme.Light : AppTheme.Dark;
            } 
        }
        private string _expression = "0";

        public string Expression
        {
            get => _expression;
            set
            {
                _expression = value;
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
        
    

