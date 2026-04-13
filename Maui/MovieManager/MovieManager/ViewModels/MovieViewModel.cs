using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Models;

namespace ProjectManager.ViewModels
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        public string Title
        {
            get => _movie.Title;
            set
            {
                _movie.Title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
            }
        }

        public string Description
        {
            get => _movie.Description;
            set
            {
                _movie.Description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Description"));
            }
        }

        public int Year
        {
            get => _movie.Year;
            set
            {
                _movie.Year = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Year"));
            }
        }

        public string Genre
        {
            get => _movie.Genre;
            set
            {
                _movie.Genre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Genre"));
            }
        }

        public double Rating
        {
            get => _movie.Rating;
            set
            {
                _movie.Rating = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Rating"));
            }
        }

        public string Icon
        {
            get => _movie.Icon;
            set
            {
                _movie.Icon = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Icon"));
            }
        }

        public Movie Movie => _movie;

        private Movie _movie;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MovieViewModel(Movie movie)
        {
            _movie = movie;
        }
    }
}
