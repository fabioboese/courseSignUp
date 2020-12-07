using CourseSignUp.Domain.Entities;
using System.Threading.Tasks;

namespace CourseSignUp.Application.Commands.CreateCourse
{
    public interface ICreateCourseCommand
    {
        Task<Course> ExecuteAsync(Course course);
    }
}