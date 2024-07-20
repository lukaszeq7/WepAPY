using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAPY.Dtos.Student
{
    public class GetStudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Brian";
        public int Points { get; set; } = 100;
        public StudentType Type { get; set; } = StudentType.Idiot;
    }
}