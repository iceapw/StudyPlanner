using System.Collections.ObjectModel;
using System.Windows.Input;
using StudyPlanner.Models;
using StudyPlanner.Services;
using StudyPlanner.Views.Courses;

namespace StudyPlanner.ViewModels
{


	public class CourseListViewModel
	{

		private readonly ApiService _apiService;

		public ObservableCollection<Course> Courses { get; set; } = new();
		public ICommand CourseTappedCommand { get; }

		public CourseListViewModel()
		{
			_apiService = new ApiService();

			CourseTappedCommand = new Command<Course>(async (course) =>
			{
				var navigationParams = new Dictionary<string, object>
	{
		{ "Course", course }
	};
				await Shell.Current.GoToAsync("//CoursesTab/CoursesPage/CourseDetailPage", navigationParams);
			});

			LoadCoursesAsync();
		}

		private async void LoadCoursesAsync()
		{
			try
			{
				var apiCourses = await _apiService.GetCourses();

				var colors = new[] { "#4F46E5", "#10B981", "#F59E0B", "#EF4444", "#3B82F6", "#8B5CF6" };
				int i = 0;

				Courses.Clear();
				foreach (var c in apiCourses)
				{
					if (c.workflow_state != "available") continue;

					Courses.Add(new Course
					{
						Id = c.id,         
						CourseCode = c.course_code,
						Title = c.name,
						ColorHex = colors[i++ % colors.Length]
					});
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error loading courses: {ex.Message}");
			}
		}
	}
}