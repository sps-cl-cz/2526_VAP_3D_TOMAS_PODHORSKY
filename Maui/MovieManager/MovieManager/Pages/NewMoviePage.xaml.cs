using ProjectManager.Models;
using ProjectManager.ViewModels;

namespace ProjectManager.Pages;

public partial class NewMoviePage : ContentPage
{
    public string Icon
    {
        get => _icon;
        set
        {
            _icon = value;
            OnPropertyChanged();
        }
    }
    private string _icon;

    MainViewModel _viewModel;

    public NewMoviePage(MainViewModel mainViewModel)
    {
        _viewModel = mainViewModel;
        InitializeComponent();
        BindingContext = this;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        string title = MovieTitle.Text;
        string description = MovieDescription.Text;
        int.TryParse(MovieYear.Text, out int year);
        string genre = MovieGenre.Text;
        double.TryParse(MovieRating.Text, System.Globalization.NumberStyles.Any,
            System.Globalization.CultureInfo.InvariantCulture, out double rating);

        Movie movie = new Movie
        {
            Title = title,
            Description = description,
            Year = year,
            Genre = genre,
            Rating = rating,
            Icon = Icon
        };

        _viewModel.Movies.Add(new MovieViewModel(movie));
        Shell.Current.GoToAsync("//MainPage");
    }
}
