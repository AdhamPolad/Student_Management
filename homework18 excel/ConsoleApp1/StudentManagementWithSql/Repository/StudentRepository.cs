using ConsoleApp1.Interface;
using ConsoleApp1.Models;
using Microsoft.Data.SqlClient;
using StudentManagementWithSql.Confics;
using System.Data;

namespace StudentManagementWithSql.Repository
{
    internal class StudentRepository : IExcelOperation
    {
        private SqlConnection sqlConnection;
        public StudentRepository()
        {
            sqlConnection = new SqlConnection(DbConfics.ConnectionStr);
            sqlConnection.Open();
        }


        public void AddRecord(Student student)
        {
            using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandText = "Insert into Students(Name, SurName, Age)Values(@Name, @SurName, @Age)";
                sqlCommand.Parameters.AddWithValue("@Name", student.Name);
                sqlCommand.Parameters.AddWithValue("@SurName", student.SurName);
                sqlCommand.Parameters.AddWithValue("@Age", student.Age);

                sqlCommand.ExecuteNonQuery();
            }
        }

        public void DeleteRecord(int id)
        {
            using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandText = "Delete from Students Where Id = @Id";
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.ExecuteNonQuery();
            }

        }

        public List<Student>? ReadRecord()
        {
            using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandText = "Select * from Students";
                using SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                List<Student> students = new List<Student>();

                while (sqlDataReader.Read())
                {
                    int id = Convert.ToInt32(sqlDataReader["Id"]);
                    string name = sqlDataReader["Name"].ToString();
                    string surName = sqlDataReader["SurName"].ToString();
                    int age = Convert.ToInt32(sqlDataReader["Age"]);
                    Student student = new Student(id, name, surName, age);
                    students.Add(student);
                }

                return students;
            }
        }

        public void UpdateRecord(int id, Student student)
        {
            using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
            {
                sqlCommand.CommandText = "Update Students set Name = @Name, SurName = @SurName, Age = @Age Where Id = @Id";
                sqlCommand.Parameters.AddWithValue("@Name", student.Name);
                sqlCommand.Parameters.AddWithValue("@SurName", student.SurName);
                sqlCommand.Parameters.AddWithValue("@Age", student.Age);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.ExecuteNonQuery();
            }

        }


        public void Dispose()
        {
            sqlConnection.Dispose();
        }
    }
}
