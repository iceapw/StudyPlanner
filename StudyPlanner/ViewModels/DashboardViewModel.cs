using StudyPlanner.Models;
using StudyPlanner.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace StudyPlanner.ViewModels
{
	public class DashboardViewModel : INotifyPropertyChanged
	{
		private readonly ApiService _apiService;

		public ObservableCollection<Course> Courses { get; set; } = new();
		public ObservableCollection<TaskItem> Tasks { get; set; } = new();

		public event PropertyChangedEventHandler PropertyChanged;

		public ICommand CourseTappedCommand { get; }

		public DashboardViewModel()
		{
			_apiService = new ApiService(new DatabaseService());

			CourseTappedCommand = new Command<Course>(async (course) =>
			{
				var navigationParams = new Dictionary<string, object>
	{
		{ "Course", course }
	};
				await Shell.Current.GoToAsync("//HomeTab/DashboardPage/CourseDetailPage", navigationParams);
			});

			LoadDataAsync();
		}

		private async void LoadDataAsync()
		{
			try
			{
				var apiCourses = await _apiService.GetCourses();

				Courses.Clear();
				foreach (var c in apiCourses)
				{
					Courses.Add(new Course
					{
						Id = c.id,
						CourseCode = c.course_code,
						Title = c.name,
						ColorHex = "#4F46E5"
					});
				}

				Tasks.Clear();
				foreach (var c in apiCourses)
				{
					var assignments = await _apiService.GetHomework(c.id);

					foreach (var a in assignments)
					{
						var due = a.due_at ?? DateTime.MaxValue;
						string status = due < DateTime.Now ? "Overdue" : "In Progress";

						Tasks.Add(new TaskItem
						{
							Title = a.name,
							CourseCode = c.course_code,
							DueDate = due,
							Status = status
						});
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error loading data: {ex.Message}");
			}
		}
	}
}