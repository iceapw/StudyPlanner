using Newtonsoft.Json;
using StudyPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyPlanner.Services
{
    public class ApiService
    {

        public async Task<List<Root_Courses>> GetCourses(string APIKey)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync($"https://canvas.instructure.com/api/v1/courses?access_token={APIKey}");

            List<Root_Courses> myDeserializedClass = JsonConvert.DeserializeObject<List<Root_Courses>>(response);
            return myDeserializedClass;
        }

        public async Task<List<Root_Assignments>> GetHomework(int courseId)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetStringAsync($"https://canvas.instructure.com/api/v1/courses/{courseId}/assignments?access_token=7~CE49HWnmL9y88VF6WntwrJQDuFN2QJuuXkBcLM46yHu6hMrtNVWyHAPfrCtQWXQN");

            List<Root_Assignments> myDeserializedClass = JsonConvert.DeserializeObject<List<Root_Assignments>>(response);
            
            return myDeserializedClass;
        }
    }
}
