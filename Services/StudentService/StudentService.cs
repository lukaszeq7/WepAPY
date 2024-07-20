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
        private readonly IMapper _mapper;

        public StudentService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> AddStudent(AddStudentDto newStudent)
        {
            var serviceResponse = new ServiceResponse<List<GetStudentDto>>();
            var student = _mapper.Map<Student>(newStudent);
            student.Id = students.Max(c => c.Id) + 1;
            students.Add(student);
            serviceResponse.Data = students.Select(c => _mapper.Map<GetStudentDto>(c)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> GetAllStudents()
        {
            var serviceResponse = new ServiceResponse<List<GetStudentDto>>();
            serviceResponse.Data = students.Select(c => _mapper.Map<GetStudentDto>(c)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStudentDto>> GetStudentById(int id)
        {
            var serviceResponse = new ServiceResponse<GetStudentDto>();
            var student = students.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetStudentDto>(student);

            return serviceResponse;             
        }
    }
}