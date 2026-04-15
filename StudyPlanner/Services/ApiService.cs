using Newtonsoft.Json;
using StudyPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyPlanner.Services
{

    //7~CE49HWnmL9y88VF6WntwrJQDuFN2QJuuXkBcLM46yHu6hMrtNVWyHAPfrCtQWXQN

    public class ApiService
    {
        private readonly DatabaseService _dbService;
        public ApiService(DatabaseService dbService)
        {
            _dbService = dbService;
        }
        public async Task<List<Root_Courses>> GetCourses()
        {
            var httpClient = new HttpClient();

            var result = await _dbService.GetKey();

            var result2 = result[0].APIKey.ToString();

            var response = await httpClient.GetStringAsync($"https://canvas.instructure.com/api/v1/courses?access_token={result[0].APIKey.ToString()}");

            List<Root_Courses> myDeserializedClass = JsonConvert.DeserializeObject<List<Root_Courses>>(response);
            return myDeserializedClass;
        }

        public async Task<List<Root_Assignments>> GetHomework(int courseId)
        {
            var httpClient = new HttpClient();

            var result = await _dbService.GetKey();

            var response = await httpClient.GetStringAsync($"https://canvas.instructure.com/api/v1/courses/{courseId}/assignments?access_token={result[0].APIKey.ToString()}");

            List<Root_Assignments> myDeserializedClass = JsonConvert.DeserializeObject<List<Root_Assignments>>(response);
            
            return myDeserializedClass;
        }
    }
}
