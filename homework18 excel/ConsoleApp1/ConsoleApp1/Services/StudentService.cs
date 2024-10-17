using ConsoleApp1.Interface;
using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    internal class StudentService : IStudentService, IDisposable
    {
        private ExcelManager _excelManager = new ExcelManager(Statics.Path.GetExcelPath());
        public void AddStudent(Student student)
        {
            _excelManager.AddRecord(student);
        }

        public void DeleteStudent(int id)
        {
            _excelManager.DeleteRecord(id);
        }

        public List<Student> GetAllStudents()
        {
            return _excelManager.ReadRecord();
        }

        public void UpdateStudents(int id, Student student)
        {
            _excelManager.UpdateRecord(id, student);
        }


        public void Dispose()
        {
            _excelManager._package.Dispose();
        }

    }
}
