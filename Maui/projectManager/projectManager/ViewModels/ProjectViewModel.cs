using System;
using System.ComponentModel;
using projectManager.Models;

namespace projectManager.ViewModels
{
    public class ProjectViewModel
    {
        private Project _project;

        public string Title
        {
            get => _project.Title;
            set
            {
                _project.Title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
            }
        }

        public string Description
        {
            get => _project.Description;
            set
            {
                _project.Description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Description"));
            }
        }

        public DateTime Date
        {
            get => _project.Date;
            set
            {
                _project.Date = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Date"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ProjectViewModel(Project project)
        {
            _project = project;
        }
    }
}