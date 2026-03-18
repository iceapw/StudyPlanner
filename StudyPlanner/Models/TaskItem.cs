using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyPlanner.Models
{
	public class TaskItem
	{
		public string Title { get; set; }
		public DateTime DueDate { get; set; }
		public string CourseCode { get; set; }
		public string Status { get; set; }
	}
}
