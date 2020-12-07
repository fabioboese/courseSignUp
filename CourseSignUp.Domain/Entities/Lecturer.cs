using CourseSignUp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Domain.Entities
{
    public class Lecturer: BaseEntity, IAggregateRoot
    {
        public string LectureName { get; set; }
    }
}
