using CourseSignUp.Domain.Entities;
using System.Threading.Tasks;

namespace CourseSignUp.Application.Queries
{
    public interface IGetCoursesCommand
    {
        Task<Course> ExecuteAsync(string id);
    }
}