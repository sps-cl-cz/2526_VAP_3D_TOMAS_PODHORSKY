using ProjectManager.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            {
                Movies.Add(new MovieViewModel(movie));
            }

            Movies.CollectionChanged += async (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    if (e.NewItems != null)
                    foreach (MovieViewModel movie in e.NewItems)
                    {
                        await _databaseService.SaveMovieAsync(movie.Movie);
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    if (e.OldItems != null)
                    foreach (MovieViewModel movie in e.OldItems)
                    {
                        await _databaseService.DeleteMovieAsync(movie.Movie);
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    if (e.OldItems != null)
                    foreach (MovieViewModel movie in e.OldItems)
                    {
                        await _databaseService.DeleteMovieAsync(movie.Movie);
                    }
                    if (e.NewItems != null)
                    foreach (MovieViewModel movie in e.NewItems)
                    {
                        await _databaseService.SaveMovieAsync(movie.Movie);
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Reset)
                {
                    await _databaseService.DeleteAllMoviesAsync();
                }
            };
        }
    }
}
