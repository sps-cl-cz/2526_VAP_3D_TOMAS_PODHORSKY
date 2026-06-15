using ProjectManager.Database;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ProjectManager.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<MovieViewModel> Movies { get; private set; } = new();
        private DatabaseService _databaseService;

        public MainViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;

            foreach (var movie in _databaseService.GetMovies())
                Movies.Add(new MovieViewModel(movie));

            Movies.CollectionChanged += async (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add && e.NewItems != null)
                    foreach (MovieViewModel vm in e.NewItems)
                        await _databaseService.SaveMovieAsync(vm.Movie);

                else if (e.Action == NotifyCollectionChangedAction.Remove && e.OldItems != null)
                    foreach (MovieViewModel vm in e.OldItems)
                        await _databaseService.DeleteMovieAsync(vm.Movie);

                else if (e.Action == NotifyCollectionChangedAction.Reset)
                    await _databaseService.DeleteAllMoviesAsync();
            };
        }
    }
}