using ConsoleApp1.Logger;
using ConsoleApp1.Models;
using Microsoft.Data.SqlClient;
using StudentManagementWithSql.Repository;
using StudentManagementWithSql.Service;

namespace StudentManagementWithSql
{
    internal class Program
    {
        static Loggers logger = new Loggers(@"C:\Users\aser\Desktop\Student Management\homework18 excel\ConsoleApp1\ConsoleApp1\Logs\");
        static void Main(string[] args)
        {
            StudentService studentService = new StudentService();

            try
            {
                while (true)
                {
                    Console.WriteLine("\n1. Add Record");
                    Console.WriteLine("2. Read Records");
                    Console.WriteLine("3. Update Record");
                    Console.WriteLine("4. Delete Record");
                    Console.WriteLine("5. Exit");
                    Console.Write("Choose an option: ");

                    int option = int.Parse(Console.ReadLine());

                    switch (option)
                    {
                        case 1:
                            AddStudents(studentService);
                            break;
                        case 2:
                            GetAllStudents(studentService);
                            break;
                        case 3:
                            UpdateStudents(studentService);
                            break;
                        case 4:
                            DeleteStudent(studentService);
                            break;
                        case 5:
                            studentService.Dispose();
                            return;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }

                }

            }

            catch (Exception exp)
            {
                logger.LogError(exp);
            }
            finally
            {
                logger.LogInfo("Proccess is end.......");
            }

        }

        private static void DeleteStudent(StudentService studentService)
        {
            Console.Write("Enter ID to delete: ");
            int deleteId = int.Parse(Console.ReadLine());
            studentService.DeleteStudent(deleteId);
        }

        private static void UpdateStudents(StudentService studentService)
        {
            Console.Write("Enter ID to update: ");
            int updateId = int.Parse(Console.ReadLine());
            Console.Write("Enter new Name: ");
            string newName = Console.ReadLine();
            Console.Write("Enter new Surname: ");
            string newSurname = Console.ReadLine();
            Console.Write("Enter new Age: ");
            int newAge = int.Parse(Console.ReadLine());
            Student newStudent = new Student(newName, newSurname, newAge);
            studentService.UpdateStudents(updateId, newStudent);
        }

        private static void GetAllStudents(StudentService studentService)
        {
            List<Student> students = studentService.GetAllStudents();

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.Id} {student.Name} {student.SurName} - Age: {student.Age}");
            }
        }

        private static void AddStudents(StudentService studentService)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter Age: ");

            if (int.TryParse(Console.ReadLine(), out int age))
            {
                Student student = new Student(name, surname, age);
                studentService.AddStudent(student); 
            }
            else
            {
                logger.LogError("Age yerine herf yazmaq olmaz!");
            }
        }


    }
}
