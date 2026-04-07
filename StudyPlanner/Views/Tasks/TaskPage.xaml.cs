namespace StudyPlanner.Views.Tasks;

public partial class TasksPage : ContentPage
{
	public TasksPage()
	{
		InitializeComponent();
	}

	private async void OnHomeTapped(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//HomeTab/DashboardPage");
	}

	private async void OnCoursesTapped(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("//CoursesTab/CoursesPage");
	}

	private async void OnTasksTapped(object sender, EventArgs e)
	{
		await Navigation.PopToRootAsync(false);
	}
}