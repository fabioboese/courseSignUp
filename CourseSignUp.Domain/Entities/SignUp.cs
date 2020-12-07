using CourseSignUp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Domain.Entities
{
    public class SignUp : BaseEntity, IAggregateRoot
    {
        public string CourseId { get; set; }
        public Student Student { get; set; }
    }
}
