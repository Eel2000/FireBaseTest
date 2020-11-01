using FireBaseTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FireBaseTest.Services.Interfaces
{
    public interface IMainService
    {
        void AddNew(Student student);
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(string id);
        void Delete(string id);
        void Edit(Student student);
    }
}
