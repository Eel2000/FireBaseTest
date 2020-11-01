using FireBaseTest.Models;
using FireBaseTest.Services.Interfaces;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FireBaseTest.Services
{
    public class MainService : IMainService
    {
        public readonly IFirebaseConfig _config;
        public readonly IFirebaseClient _firebaseClient;

        public MainService()
        {
            _config = new FirebaseConfig { AuthSecret = "8JSYGrG7FyQcz27bZlYU3mzMIGy3ylmIAzmbTK8p", BasePath = "https://aspnetcorefirebasetest.firebaseio.com/" };
            _firebaseClient = new FireSharp.FirebaseClient(_config);
        }

        public void AddNew(Student student)
        {
            var data = student;
            PushResponse response = _firebaseClient.Push("Student/", data);
            data.Id = response.Result.name;

            SetResponse setResponse = _firebaseClient.Set("Student/" + data.Id, data);
        }

        public void Delete(string id)
        {
            FirebaseResponse firebaseResponse = _firebaseClient.Delete("Student/" + id);
            Debug.Write(firebaseResponse.Body.ToString());
        }

        public void Edit(Student student)
        {
            SetResponse setResponse = _firebaseClient.Set("Student/" + student.Id, student);
            Debug.WriteLine(setResponse.Body.ToString());
        }

        public IEnumerable<Student> GetAllStudents()
        {
            FirebaseResponse firebaseResponse = _firebaseClient.Get("Student");

            dynamic data = JsonConvert.DeserializeObject<dynamic>(firebaseResponse.Body);

            var listOfStudents = new List<Student>();

            foreach (var students in data)
            {
                listOfStudents.Add(JsonConvert.DeserializeObject<Student>(((JProperty)students).Value.ToString()));
            }

            return listOfStudents;
        }

        public Student GetStudent(string id)
        {
            FirebaseResponse firebaseResponse = _firebaseClient.Get("Student/"+id);

            Student data = JsonConvert.DeserializeObject<Student>(firebaseResponse.Body);

            return (data);
        }
    }
}
