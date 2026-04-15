using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using StudyPlanner.Models;
using StudyPlanner.Services;

namespace StudyPlanner.ViewModels
{
	[QueryProperty(nameof(Course), "Course")]
	public class CourseDetailViewModel : INotifyPropertyChanged
	{
		private readonly ApiService _apiService;

		private Course _course;

		public event PropertyChangedEventHandler PropertyChanged;

		public ICommand BackCommand { get; }

		public Course Course
		{
			get => _course;
			set
			{
				_course = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Course)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CourseCode)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
				LoadTasksAsync();
			}
		}

		public string CourseCode => _course?.CourseCode;
		public string Title => _course?.Title;

		public ObservableCollection<TaskItem> Tasks { get; set; } = new();

		public CourseDetailViewModel()
		{
			_apiService = new ApiService(new DatabaseService());

			BackCommand = new Command(async () =>
			{
				await Shell.Current.GoToAsync("..");
			});
		}

		private async void LoadTasksAsync()
		{
			try
			{
				if (_course == null) return;

				var assignments = await _apiService.GetHomework(_course.Id);

				var valid = assignments
					.Where(a => a.workflow_state == "published")
					.ToList();

				Tasks.Clear();
				foreach (var a in valid)
				{
					var due = a.due_at ?? DateTime.MaxValue;
					Tasks.Add(new TaskItem
					{
						Title = a.name,
						CourseCode = _course.CourseCode,
						DueDate = due,
						Status = due < DateTime.Now ? "Overdue" : "In Progress"
					});
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error loading tasks: {ex.Message}");
			}
		}
	}
}