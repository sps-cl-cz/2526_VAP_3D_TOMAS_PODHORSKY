using ProjectManager.Database;
using ProjectManager.ViewModels;

namespace ProjectManager.Pages;

[QueryProperty(nameof(Movie), "Movie")]
public partial class MovieDetailPage : ContentPage
{
    public MovieViewModel Movie
    {
        get => _viewModel;
        set
        {
            _viewModel = value;
            BindingContext = value;
        }
    }
    MovieViewModel _viewModel;
    DatabaseService _databaseService;

    public MovieDetailPage(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        InitializeComponent();
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        await _databaseService.SaveMovieAsync(Movie.Movie);
        await Shell.Current.GoToAsync("..");
    }

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}
