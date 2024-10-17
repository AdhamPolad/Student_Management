using ConsoleApp1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    internal class Student 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }

        public Student(int id, string name, string surName, int age)
        {
            Id = id;
            Name = name;
            SurName = surName;
            Age = age;
        }


        
    }
}
