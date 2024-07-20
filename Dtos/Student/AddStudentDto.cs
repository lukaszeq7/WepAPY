using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAPY.Dtos.Student
{
    public class AddStudentDto
    {
        public string Name { get; set; } = "Brian";
        public int Points { get; set; } = 100;
        public StudentType Type { get; set; } = StudentType.Idiot;
    }
}