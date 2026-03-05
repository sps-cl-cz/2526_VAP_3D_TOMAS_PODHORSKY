using Microsoft.Maui.Controls;

namespace MauiPiskvorky
{
    public partial class MainPage : ContentPage
    {
        private enum Player
        {
            X,
            O
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

        private readonly Label[] _cells;
        private Player _currentPlayer = Player.X;

        private string _statusText = "Na tahu: X";
        public string StatusText
        {
            get => _statusText;
            set
            {
                _statusText = value;
                OnPropertyChanged(nameof(StatusText));
            }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            _cells = new Label[]
            {
                Cell0, Cell1, Cell2,
                Cell3, Cell4, Cell5,
                Cell6, Cell7, Cell8
            };
        }

        private void OnCellTapped(object sender, TappedEventArgs e)
        {
            if (!(e.Parameter is string param))
                return;

            if (!int.TryParse(param, out int index))
                return;

            if (!string.IsNullOrEmpty(_cells[index].Text))
                return;

            _cells[index].Text = _currentPlayer.ToString();
            _cells[index].TextColor = _currentPlayer == Player.X ? Colors.Red : Colors.Blue;

            _currentPlayer = _currentPlayer == Player.X ? Player.O : Player.X;
            StatusText = $"Na tahu: {_currentPlayer}";
        }

        private void OnNewGameClicked(object sender, EventArgs e)
        {
            foreach (Label cell in _cells)
                cell.Text = string.Empty;

            _currentPlayer = Player.X;
            StatusText = "Na tahu: X";
        }
    }
}