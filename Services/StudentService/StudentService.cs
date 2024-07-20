using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAPY.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new List<Student> {
            new Student(),
            new Student { Id = 1, Name = "Rambo" }
        };

        public async Task<List<Student>> AddStudent(Student newStudent)
        {
            students.Add(newStudent);
            return students;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return students;
        }

        public async Task<Student> GetStudentById(int id)
        {
             var student = students.FirstOrDefault(c => c.Id == id);
             if(student != null)
                return student;

            throw new Exception("Student not found");
        }
    }
}