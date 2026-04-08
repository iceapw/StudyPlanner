
using CommunityToolkit.Maui.Views;
using StudyPlanner.Services;
using StudyPlanner.Views.Popups;
using StudyPlanner.Models;
using Xamarin.Google.ErrorProne.Annotations;

namespace StudyPlanner.Views.Dashboard;

public partial class DashboardPage : ContentPage
{
	private readonly DatabaseService _dbService;

	public DashboardPage(DatabaseService dbService)
	{
		_dbService = dbService;
		InitializeComponent();
	}

	private async void OnHomeTapped(object sender, EventArgs e)
	{
		await Navigation.PopToRootAsync(false);
	}

	private async void OnCoursesTapped(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//CoursesTab/CoursesPage");
	}

	private async void OnTasksTapped(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//TasksTab/TasksPage");
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();

		List<Key> resultOfGetKey = await _dbService.GetKey();

		if (resultOfGetKey.Count == 0)
		{
			var popup = new APIPopup(_dbService, new Entry());
			

			var result = await this.ShowPopupAsync(popup);
			
		}
	}
}