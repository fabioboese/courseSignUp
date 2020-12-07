using System.Threading.Tasks;

namespace CourseSignUp.Application.Commands.SignUp
{
    public interface ISignUpConfirmationCommand
    {
        Task ExecuteAsync(Domain.Entities.SignUp signUp);
    }
}