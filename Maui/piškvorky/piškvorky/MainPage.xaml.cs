using Microsoft.Maui.Controls;

namespace MauiPiskvorky
{
    public partial class MainPage : ContentPage
    {
        // ── Téma ───────────────────────────────────────────────────────────────
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

        // ── Herní stav ─────────────────────────────────────────────────────────
        private readonly string[] _board = new string[9];
        private readonly Label[] _cells;

        private bool _xIsNext = true;
        private bool _gameOver = false;

        private string _statusText = "Na tahu: X";
        public string StatusText
        {
            get => _statusText;
            set { _statusText = value; OnPropertyChanged(nameof(StatusText)); }
        }

        private static readonly int[][] WinLines =
        {
            new[] { 0, 1, 2 }, new[] { 3, 4, 5 }, new[] { 6, 7, 8 },
            new[] { 0, 3, 6 }, new[] { 1, 4, 7 }, new[] { 2, 5, 8 },
            new[] { 0, 4, 8 }, new[] { 2, 4, 6 }
        };

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            // Pole odkazů na labely políček
            _cells = new Label[] { Cell0, Cell1, Cell2, Cell3, Cell4, Cell5, Cell6, Cell7, Cell8 };
        }

        // ── Kliknutí na políčko ────────────────────────────────────────────────
        private void OnCellTapped(object sender, TappedEventArgs e)
        {
            if (_gameOver) return;
            if (e.Parameter is not string param || !int.TryParse(param, out int index)) return;
            if (!string.IsNullOrEmpty(_board[index])) return;

            string symbol = _xIsNext ? "X" : "O";
            _board[index] = symbol;

            // Nastav label — X červeně, O modře
            _cells[index].Text = symbol;
            _cells[index].TextColor = _xIsNext ? Colors.Red : Colors.Blue;

            if (CheckWinner(symbol))
            {
                StatusText = $"Vyhrál: {symbol}!";
                _gameOver = true;
                return;
            }

            if (IsBoardFull())
            {
                StatusText = "Remiza!";
                _gameOver = true;
                return;
            }

            _xIsNext = !_xIsNext;
            StatusText = $"Na tahu: {(_xIsNext ? "X" : "O")}";
        }

        private void OnNewGameClicked(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                _board[i] = string.Empty;
                _cells[i].Text = string.Empty;
            }

            _xIsNext = true;
            _gameOver = false;
            StatusText = "Na tahu: X";
        }

        private bool CheckWinner(string symbol)
        {
            foreach (var line in WinLines)
                if (_board[line[0]] == symbol && _board[line[1]] == symbol && _board[line[2]] == symbol)
                    return true;
            return false;
        }

        private bool IsBoardFull()
        {
            foreach (var cell in _board)
                if (string.IsNullOrEmpty(cell)) return false;
            return true;
        }
    }
}
