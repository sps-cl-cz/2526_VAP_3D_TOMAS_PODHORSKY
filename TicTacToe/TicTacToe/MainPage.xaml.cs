namespace TicTacToe
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
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

    }

}
