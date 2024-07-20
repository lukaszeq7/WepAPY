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
        private readonly DataContext _context;

        public StudentService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> AddStudent(AddStudentDto newStudent)
        {
            var serviceResponse = new ServiceResponse<List<GetStudentDto>>();
            var student = _mapper.Map<Student>(newStudent);

            _context.Students.Add(student);
            await _context.SaveChangesAsync();            

            serviceResponse.Data = await _context.Students.Select(c => _mapper.Map<GetStudentDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> DeleteStudents(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetStudentDto>>();

            try
            {
                var student = await _context.Students.FirstOrDefaultAsync(c => c.Id == id);
                if(student is null)
                    throw new Exception($"Student with Id '{id}' not found.");

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                serviceResponse.Data = await _context.Students.Select(c => _mapper.Map<GetStudentDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }            

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> GetAllStudents()
        {
            var serviceResponse = new ServiceResponse<List<GetStudentDto>>();
            var dbStudents = await _context.Students.ToListAsync();
            serviceResponse.Data = dbStudents.Select(c => _mapper.Map<GetStudentDto>(c)).ToList();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStudentDto>> GetStudentById(int id)
        {
            var serviceResponse = new ServiceResponse<GetStudentDto>();
            var dbStudent = await _context.Students.FirstOrDefaultAsync(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetStudentDto>(dbStudent);

            return serviceResponse;             
        }

        public async Task<ServiceResponse<GetStudentDto>> UpdateStudent(UpdateStudentDto updatedStudent)
        {
            var serviceResponse = new ServiceResponse<GetStudentDto>();

            try
            {
                var dbStudent = await _context.Students.FirstOrDefaultAsync(c => c.Id == updatedStudent.Id);
                if(dbStudent is null)
                    throw new Exception($"Student with Id '{updatedStudent.Id}' not found.");

                dbStudent.Name = updatedStudent.Name;
                dbStudent.Points = updatedStudent.Points;
                dbStudent.Type = updatedStudent.Type;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetStudentDto>(dbStudent);
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }            

            return serviceResponse;
        }
    }
}