using ProjectManager.Models;
using ProjectManager.ViewModels;

namespace ProjectManager.Pages;

public partial class AddMoviePage : ContentPage
{
    public string ImagePath
    {
        get => _imagePath;
        set { _imagePath = value; OnPropertyChanged(); }
    }
    private string _imagePath;

    MainViewModel _viewModel;

    public AddMoviePage(MainViewModel mainViewModel)
    {
        _viewModel = mainViewModel;
        InitializeComponent();
        BindingContext = this;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(MovieTitle.Text))
        {
            DisplayAlert("Chyba", "Zadejte název filmu.", "OK");
            return;
        }

        int.TryParse(MovieYear.Text, out int year);
        double.TryParse(MovieRating.Text, System.Globalization.NumberStyles.Any,
            System.Globalization.CultureInfo.InvariantCulture, out double rating);

        var movie = new Movie
        {
            Title = MovieTitle.Text,
            Description = MovieDescription.Text,
            Year = year,
            Genre = MovieGenre.Text,
            Rating = rating,
            ImagePath = ImagePath
        };

        _viewModel.Movies.Add(new MovieViewModel(movie));
        Shell.Current.GoToAsync("//MainPage");
    }
}