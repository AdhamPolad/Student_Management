using ConsoleApp1.Interface;
using ConsoleApp1.Models;
using StudentManagementWithSql.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementWithSql.Service
{
    internal class StudentService : IStudentService
    {
        private StudentRepository studentRepository;

        public StudentService()
        {
            studentRepository = new StudentRepository();
        }
        public void AddStudent(Student student)
        {
            studentRepository.AddRecord(student);
        }

        public void DeleteStudent(int id)
        {
            studentRepository?.DeleteRecord(id);
        }

        public List<Student> GetAllStudents()
        {
            return studentRepository.ReadRecord();
        }

        public void UpdateStudents(int id, Student student)
        {
            studentRepository.UpdateRecord(id, student);
        }


        public void Dispose()
        {
            studentRepository?.Dispose();
        }
    }
}
