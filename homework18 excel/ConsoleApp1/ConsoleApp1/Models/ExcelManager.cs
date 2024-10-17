using ConsoleApp1.Interface;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class ExcelManager : IExcelOperation, IDisposable
    {
        private readonly string _filePath;
        public readonly ExcelPackage _package;
        private ExcelWorksheet _worksheet;

        public ExcelManager(string filePath)
        {
            _filePath = filePath;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            _package = new ExcelPackage(new FileInfo(_filePath)); ;

            InitializeWorksheet();
        }

        private void InitializeWorksheet()
        {
            _worksheet = _package.Workbook.Worksheets.Count > 0
                ? _package.Workbook.Worksheets[0] :
                _package.Workbook.Worksheets.Add("Students");

            if(_worksheet.Dimension == null)
            {
                _worksheet.Cells[1, 1].Value = "Id";
                _worksheet.Cells[1, 2].Value = "Name";
                _worksheet.Cells[1, 3].Value = "Surname";
                _worksheet.Cells[1, 4].Value = "Age";
                _package.SaveAs(new FileInfo(_filePath));
            }
        }

        public void AddRecord(Student student)
        {
            int row = _worksheet.Dimension.Rows + 1;

            _worksheet.Cells[row, 1].Value = student.Id;
            _worksheet.Cells[row, 2].Value = student.Name;
            _worksheet.Cells[row, 3].Value = student.SurName;
            _worksheet.Cells[row, 4].Value = student.Age;
            _package.SaveAs(new FileInfo(_filePath));
        }

        public List<Student>? ReadRecord()
        {
            List<Student>? students = new List<Student>();
            Student student;
            for(int row = 2; row <= _worksheet.Dimension.Rows; row++)
            {
                int id = Convert.ToInt32(_worksheet.Cells[row, 1].Value);
                string? name = _worksheet.Cells[row, 2].Value.ToString();
                string? surName = _worksheet.Cells[row, 3].Value.ToString();
                int age = Convert.ToInt32(_worksheet.Cells[row, 4].Value);
                student = new Student(id, name, surName, age);
                if(student != null)
                {
                    students.Add(student);
                }
                
            }

            return students;
        }

        public void UpdateRecord(int id, Student student)
        {
            int row = FindRecordRow(id);

            if(row > 0)
            {
                _worksheet.Cells[row, 1].Value = student.Id;
                _worksheet.Cells[row, 2].Value = student.Name;
                _worksheet.Cells[row, 3].Value = student.SurName;
                _worksheet.Cells[row, 4].Value = student.Age;
                _package.SaveAs(new FileInfo(_filePath));
            }


        }

        public void DeleteRecord(int id)
        {
            int row = FindRecordRow(id);

            if(row > 0)
            {
                _worksheet.DeleteRow(row);
                _package.SaveAs(new FileInfo(_filePath));
            }
        }



        private int FindRecordRow(int id)
        {
            for (int row = 2; row <= _worksheet.Dimension.Rows; row++)
            {
                if (_worksheet.Cells[row, 1].Value != null &&
                    _worksheet.Cells[row, 1].Value.ToString() == id.ToString())
                {
                    return row;
                }
            }
            return -1;
        }
        public void Dispose()
        {
            _package.Dispose();
        }

    }
}
