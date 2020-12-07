using CourseSignUp.Domain.Entities;
using System.Threading.Tasks;

namespace CourseSignUp.Application.Commands.CreateLecture
{
    public interface ICreateLecturerCommand
    {
        Task<Lecturer> ExecuteAsync(Lecturer lecturer);
    }
}