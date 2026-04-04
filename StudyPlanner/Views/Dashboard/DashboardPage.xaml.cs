namespace StudyPlanner.Views.Dashboard;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
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
}