using CourseSignUp.Application.Response;
using CourseSignUp.Domain.Entities;
using CourseSignUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseSignUp.Application.Queries
{
    public class GetStatisticsCommand : IGetStatisticsCommand
    {
        private IRepository _repository;
        public GetStatisticsCommand(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetStatisticsResponse>> ExecuteAsync()
        {
            var list = new List<GetStatisticsResponse>();
            var courses = await _repository.ListAsync<Course>();
            foreach (var course in courses)
                list.Add(new GetStatisticsResponse
                {
                    Id = course.Id,
                    Name = course.Name,
                    MinimumAge = course.Statistics.MinAge,
                    MaximumAge = course.Statistics.MaxAge,
                    AverageAge = course.NumberOfStudents == 0 ? 0 : course.Statistics.SumAge / course.NumberOfStudents
                });

            return list;
        }
    }
}
