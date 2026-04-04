namespace StudyPlanner.Views.Courses;

public partial class CourseDetailPage : ContentPage
{
	public CourseDetailPage()
	{
		InitializeComponent();
		BindingContext = new ViewModels.CourseDetailViewModel();
	}
}