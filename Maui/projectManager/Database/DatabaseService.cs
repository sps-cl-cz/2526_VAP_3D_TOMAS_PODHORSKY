using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Models;
using SQLite;

namespace ProjectManager.Database
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _connection;
        public DatabaseService(string path = "projects.db3")
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, path));
            _connection.CreateTableAsync<Project>().Wait();
        }

        public Task<List<Project>> GetAllProjectsAsync()
        {
            return _connection.Table<Project>().ToListAsync();
        }
        public List<Project> GetAllProjects()
        {
            var task = GetAllProjectsAsync();
            task.Wait();
            return task.Result;
        }

        public Task<int> SaveProjectAsync(Project project)
        {
            if (project.Id == 0) return _connection.InsertAsync(project);
            else return _connection.UpdateAsync(project);
        }
        
        public Task<int> DeleteProjectAsync(Project project)
        {
            return _connection.DeleteAsync(project);
        }

        public Task<int> DeleteAllProjects()
        {
            return _connection.DeleteAllAsync<Project>();
        }
    }
}
