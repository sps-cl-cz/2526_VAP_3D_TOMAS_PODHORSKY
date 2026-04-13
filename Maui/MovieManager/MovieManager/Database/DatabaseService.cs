using ProjectManager.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Database
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath = "movies.db3")
        {
            _database = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, dbPath));
            _database.CreateTableAsync<Movie>().Wait();
        }

        public List<Movie> GetMovies()
        {
            var task = GetMoviesAsync();
            task.Wait();
            return task.Result;
        }

        public Task<List<Movie>> GetMoviesAsync()
        {
            return _database.Table<Movie>().ToListAsync();
        }

        public Task<int> SaveMovieAsync(Movie movie)
        {
            if (movie.Id != 0)
                return _database.UpdateAsync(movie);
            else
                return _database.InsertAsync(movie);
        }

        public Task<int> DeleteMovieAsync(Movie movie)
        {
            return _database.DeleteAsync(movie);
        }

        public Task<int> DeleteAllMoviesAsync()
        {
            return _database.DeleteAllAsync<Movie>();
        }
    }
}
