using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WepAPY.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private static Student student = new Student();

        [HttpGet]
        public ActionResult<Student> Get()
        {
            return Ok(student);
        }
    }
}