using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAPY.Services.StudentService
{
    public interface IStudentService
    {
        Task<ServiceResponse<List<Student>>> GetAllStudents();
        Task<ServiceResponse<Student>> GetStudentById(int id);
        Task<ServiceResponse<List<Student>>> AddStudent(Student newStudent);
    }
}