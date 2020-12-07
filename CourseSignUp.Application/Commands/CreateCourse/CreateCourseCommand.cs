using CourseSignUp.Domain.Entities;
using CourseSignUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CourseSignUp.Application.Commands.CreateCourse
{
    public class CreateCourseCommand : ICreateCourseCommand
    {
        private IRepository _repository;
        public CreateCourseCommand(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Course> ExecuteAsync(Course course)
        {
            course.Id = new Guid(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(course.Name))).ToString();
            return await _repository.AddAsync(course);
        }
    }
}
