using System.Threading.Tasks;

namespace CourseSignUp.Application.Commands.SignUp
{
    public interface ISignUpRequestCommand
    {
        Task<string> ExecuteAsync(Domain.Entities.SignUp signUp);
    }
}