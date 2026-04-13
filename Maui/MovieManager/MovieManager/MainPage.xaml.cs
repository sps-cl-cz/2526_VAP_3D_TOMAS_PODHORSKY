using ProjectManager.Pages;
using ProjectManager.ViewModels;

namespace ProjectManager
{
    public partial class MainPage : ContentPage
    {
        MainViewModel _viewModel;

        public MainPage(MainViewModel mainViewModel)
        {
            _viewModel = mainViewModel;
            InitializeComponent();
            BindingContext = _viewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            MovieViewModel movieViewModel = (MovieViewModel)button.BindingContext;
            _viewModel.Movies.Remove(movieViewModel);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Shell.Current.GoToAsync(nameof(MovieDetailPage), new Dictionary<string, object> { { "Movie", e.Item } });
        }
    }
}
