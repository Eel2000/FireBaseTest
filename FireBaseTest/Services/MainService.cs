using FireBaseTest.Models;
using FireBaseTest.Services.Interfaces;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Student GetStudent(string id)
        {
            throw new NotImplementedException();
        }
    }
}
