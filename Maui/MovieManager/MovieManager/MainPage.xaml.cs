using ProjectManager.Pages;
using ProjectManager.ViewModels;
using ProjectManager.Models; // Ujisti se, že máš správné usingy

namespace ProjectManager
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _viewModel;

        public MainPage(MainViewModel mainViewModel)
        {
            _viewModel = mainViewModel;
            InitializeComponent();
            BindingContext = _viewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is MovieViewModel movieViewModel)
            {
                _viewModel.Movies.Remove(movieViewModel);
            }
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                await Shell.Current.GoToAsync(nameof(MovieDetailPage), new Dictionary<string, object> { { "Movie", e.Item } });
            }
        }
    }
}