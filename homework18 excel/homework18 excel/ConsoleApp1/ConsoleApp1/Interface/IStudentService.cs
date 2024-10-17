using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interface
{
    internal interface IStudentService
    {
        void AddStudent(Student student);
        List<Student> GetAllStudents();
        void UpdateStudents(int id, Student student);
        void DeleteStudent(int id);
    }
}
