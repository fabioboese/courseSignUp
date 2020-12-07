using CourseSignUp.Domain.Entities;
using CourseSignUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseSignUp.Application.Queries
{
    public class GetCoursesCommand : IGetCoursesCommand
    {
        private IRepository _repository;
        public GetCoursesCommand(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Course> ExecuteAsync(string id)
        {
            var course = await _repository.GetByIdAsync<Course>(id);
            return course;
        }
    }
}
