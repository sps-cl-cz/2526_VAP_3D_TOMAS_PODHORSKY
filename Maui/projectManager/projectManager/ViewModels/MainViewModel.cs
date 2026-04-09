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
        public ObservableCollection<ProjectViewModel> Projects { get; private set; } = new();
        private DatabaseService _databaseService;
        public MainViewModel(DatabaseService databaseService)
        {
            _databaseService = databaseService;

            foreach (var project in _databaseService.GetProjects())
            {
                Projects.Add(new ProjectViewModel(project));
            }

            Projects.CollectionChanged += async (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    if (e.NewItems != null)
                    foreach (ProjectViewModel project in e.NewItems)
                    {
                        await _databaseService.SaveProjectAsync(project.Project);
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    if (e.OldItems != null)
                    foreach (ProjectViewModel project in e.OldItems)
                    {
                        await _databaseService.DeleteProjectAsync(project.Project);
                    }
                } else if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    if (e.OldItems != null)
                    foreach (ProjectViewModel project in e.OldItems)
                    {
                        await _databaseService.DeleteProjectAsync(project.Project);
                    }
                    if (e.NewItems != null)
                    foreach (ProjectViewModel project in e.NewItems)
                    {
                        await _databaseService.SaveProjectAsync(project.Project);
                    }
                } else if (e.Action == NotifyCollectionChangedAction.Reset)
                {
                    await _databaseService.DeleteAllProjectsAsync();
                }
            };
        }
    }
}