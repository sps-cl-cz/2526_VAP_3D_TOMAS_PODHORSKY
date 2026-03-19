using System.Collections.ObjectModel;
using projectManager.Models;

namespace projectManager.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Project> Projects { get; } = new ObservableCollection<Project>();
    }
}