using CourseSignUp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Domain.Entities
{
    public class Student
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
