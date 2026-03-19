using projectManager.Pages;
using projectManager.ViewModels;

namespace projectManager
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        MainViewModel _viewModel;

        public MainPage(MainViewModel mainViewModel)
        {
            _viewModel = mainViewModel;
            InitializeComponent();
            BindingContext = _viewModel;
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(ProjectDetailsPage));
        }
    }
}