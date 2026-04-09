using ProjectManager.Models;
using ProjectManager.ViewModels;

namespace ProjectManager.Pages;

public partial class NewProjectPage : ContentPage
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
	public NewProjectPage(MainViewModel mainViewModel)
	{
		_viewModel = mainViewModel;
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		string title = ProjectTitle.Text;
		string description = ProjectDescription.Text;
		DateTime date = ProjectDate.Date;
		Project project = new Project
		{
			Title = title,
			Description = description,
			Date = date,
			Icon = Icon,
		};
		_viewModel.Projects.Add(new ProjectViewModel(project));
		Shell.Current.GoToAsync("//MainPage");
    }

	private async void FileSelect_Clicked(object sender, EventArgs e)
	{
		var res = await FilePicker.PickAsync(PickOptions.Images);
		if (res != null)
		{
			var path = res.FullPath;
		}
	}
}