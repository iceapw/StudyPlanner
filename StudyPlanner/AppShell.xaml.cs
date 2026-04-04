namespace StudyPlanner;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("CourseDetailPage", typeof(Views.Courses.CourseDetailPage));
	}
}