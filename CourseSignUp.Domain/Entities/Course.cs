using CourseSignUp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseSignUp.Domain.Entities
{
    public class Course : BaseEntity, IAggregateRoot
    {
        public Course()
        {
            this.Statistics = new CourseStatistics(this);
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int NumberOfStudents { get; set; }
        public string LecturerId { get; set; }
        public CourseStatistics Statistics { get; private set; }
    }

    
}
