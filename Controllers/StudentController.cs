using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WepAPY.Services.StudentService;

namespace WepAPY.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<Student>>>> Get()
        {
            return Ok(await _studentService.GetAllStudents());
        }

        [HttpGet("{id}")]
         public async Task<ActionResult<ServiceResponse<List<Student>>>> GetSingle(int id)
        {
            return Ok(await _studentService.GetStudentById(id));
        }
        
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Student>>>> AddStudent(Student newStudent)
        {        
            return Ok(await _studentService.AddStudent(newStudent));
        }
    }
}