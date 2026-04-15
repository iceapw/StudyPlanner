using StudyPlanner.Models;
using StudyPlanner.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace StudyPlanner.ViewModels
{
	public class TasksViewModel : INotifyPropertyChanged
	{
		private readonly ApiService _apiService;
		private string _selectedCategory = "InProgress";

		public event PropertyChangedEventHandler PropertyChanged;

		public ObservableCollection<TaskItem> FilteredTasks { get; set; } = new();
		private List<TaskItem> _allTasks = new();

		public bool InProgressSelected => _selectedCategory == "InProgress";
		public bool OverdueSelected => _selectedCategory == "Overdue";
		public bool CompletedSelected => _selectedCategory == "Completed";

		public ICommand SelectCategoryCommand { get; }

		public TasksViewModel()
		{
			_apiService = new ApiService(new DatabaseService());

			SelectCategoryCommand = new Command<string>((category) =>
			{
				_selectedCategory = category;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InProgressSelected)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OverdueSelected)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CompletedSelected)));
				ApplyFilter();
			});

			LoadTasksAsync();
		}

		private async void LoadTasksAsync()
		{
			try
			{
				var apiCourses = await _apiService.GetCourses();
				_allTasks.Clear();

				foreach (var c in apiCourses.Where(c => c.workflow_state == "available"))
				{
					var assignments = await _apiService.GetHomework(c.id);

					foreach (var a in assignments)
					{
						var due = a.due_at ?? DateTime.MaxValue;
						string status;

						if (a.workflow_state == "published")
						{
							status = due < DateTime.Now ? "Overdue" : "In Progress";
						}
						else
						{
							status = "Completed";
						}

						_allTasks.Add(new TaskItem
						{
							Title = a.name,
							CourseCode = c.course_code,
							DueDate = due,
							Status = status
						});
					}
				}

				ApplyFilter();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error loading tasks: {ex.Message}");
			}
		}

		private void ApplyFilter()
		{
			FilteredTasks.Clear();

			var filtered = _selectedCategory switch
			{
				"InProgress" => _allTasks.Where(t => t.Status == "In Progress"),
				"Overdue" => _allTasks.Where(t => t.Status == "Overdue"),
				"Completed" => _allTasks.Where(t => t.Status == "Completed"),
				_ => _allTasks.AsEnumerable()
			};

			foreach (var t in filtered)
				FilteredTasks.Add(t);
		}
	}
}