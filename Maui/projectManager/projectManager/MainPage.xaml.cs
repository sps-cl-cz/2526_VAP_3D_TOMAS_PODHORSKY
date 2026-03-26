using ProjectManager.Pages;
using ProjectManager.ViewModels;

namespace ProjectManager
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

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is ProjectViewModel viewModel)
            {
                Shell.Current.GoToAsync(nameof(ProjectDetailsPage), new Dictionary<string, object>
                {
                    { "project", viewModel }
                });
            }
        }
    }

}
