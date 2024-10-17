using ConsoleApp1.Logger;
using ConsoleApp1.Models;
using ConsoleApp1.Services;
using ConsoleApp1.Statics;
using OfficeOpenXml;


namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Loggers logger = new Loggers(Statics.Path.GetLogPath());
            try
            {
                using (StudentService studentService = new StudentService())
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
                                return;
                            default:
                                Console.WriteLine("Invalid option.");
                                break;
                        }


                    }
                }
            }

            catch (Exception exp)
            {
                logger.LogError(exp);
                
            }
            finally
            {
                logger.LogInfo("process is end");
            }



        }


        static void AddStudents(StudentService studentService)
        {
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter Age: ");

            if(int.TryParse(Console.ReadLine(), out int age))
            {
                Student student = new Student(id, name, surname, age);
                studentService.AddStudent(student);
            }
            else
            {
                throw new Exception("Age yerine herf yazmaq olmaz!");
            }
            
        }

        static void GetAllStudents(StudentService studentService)
        {
            List<Student> students = studentService.GetAllStudents();

            foreach (Student student in students)
            {
                Console.WriteLine($"{student.Id} {student.Name} {student.SurName} - Age: {student.Age}");
            }
        }

        static void UpdateStudents(StudentService studentService)
        {
            Console.Write("Enter ID to update: ");
            int updateId = int.Parse(Console.ReadLine());
            Console.Write("Enter new Name: ");
            string newName = Console.ReadLine();
            Console.Write("Enter new Surname: ");
            string newSurname = Console.ReadLine();
            Console.Write("Enter new Age: ");
            int newAge = int.Parse(Console.ReadLine());
            Student newStudent = new Student(updateId, newName, newSurname, newAge);
            studentService.UpdateStudents(updateId, newStudent);
        }
        static void DeleteStudent(StudentService studentService)
        {
            Console.Write("Enter ID to delete: ");
            int deleteId = int.Parse(Console.ReadLine());
            studentService.DeleteStudent(deleteId);
        }

    }
}
