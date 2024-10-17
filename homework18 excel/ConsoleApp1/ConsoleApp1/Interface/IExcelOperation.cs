using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interface
{
    internal interface IExcelOperation
    {
        void AddRecord(Student student);
        List<Student>? ReadRecord();
        void UpdateRecord(int id, Student student);
        void DeleteRecord(int id);
    }
}
