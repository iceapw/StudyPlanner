using System.Collections.ObjectModel;
using StudyPlanner.Models;
using System.Linq;

namespace StudyPlanner.ViewModels
{
	public class DashboardViewModel
	{
		public ObservableCollection<Course> Courses { get; set; }
		public ObservableCollection<TaskItem> Tasks { get; set; }

		public DashboardViewModel()
		{
			Courses = new ObservableCollection<Course>
			{
				new Course { CourseCode = "CS 201", Title = "Computer Science" },
				new Course { CourseCode = "MATH 201", Title = "Math" },
				new Course { CourseCode = "ENG 101", Title = "English" },
				new Course { CourseCode = "PHYS 150", Title = "Physics" }
			};

			var allTasks = new List<TaskItem>
			{
				new TaskItem { Title = "Task1", CourseCode = "PHYS 150", DueDate = DateTime.Now.AddDays(1), Status = "In Progress" },
				new TaskItem { Title = "Task2", CourseCode = "ENG 101", DueDate = DateTime.Now.AddDays(2), Status = "Done" },
				new TaskItem { Title = "Task3", CourseCode = "CS 201", DueDate = DateTime.Now.AddDays(-1), Status = "Overdue" },
				new TaskItem { Title = "Task4", CourseCode = "MATH 201", DueDate = DateTime.Now.AddDays(3), Status = "In Progress" }
			};


			var activeTasks = allTasks.Where(task => task.Status != "Done");

			Tasks = new ObservableCollection<TaskItem>(activeTasks);
		}
	}
}