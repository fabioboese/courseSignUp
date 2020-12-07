using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Domain.Entities
{
    public class CourseStatistics 
    {
        public CourseStatistics(Course course)
        {
            this.Course = course;
        }

        public Course Course { get; private set; }

        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int SumAge { get; set; }
    }
}
