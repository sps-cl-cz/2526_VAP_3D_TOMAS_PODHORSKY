using ProjectManager.Pages;
using ProjectManager.ViewModels;
using ProjectManager.Models;

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

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is ProjectViewModel project)
            {
                _viewModel.Projects.Remove(project);
            }
        }
    }

}
