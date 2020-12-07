using CourseSignUp.Domain.Interfaces;
using CourseSignUp.Domain.Notifications;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignUp.Domain.Handlers
{
    public class SignUpCompletedEmailNotificationHandler : INotificationHandler<SignUpCompletedNotification>
    {
        private IEmailSender _emailSender;

        public SignUpCompletedEmailNotificationHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task Handle(SignUpCompletedNotification notification, CancellationToken cancellationToken)
        {
            var signUp = notification.SignUp;
            await _emailSender.SendEmailAsync(
                "noreply@chamaUniversity.com",
                signUp.Student.Email,
                "",
                $"SignUp Confirmed",
                $"Dear, {signUp.Student.Name}" +
                $"Your sign up to the {signUp.CourseId} course was confirmed!"); // TODO: improve parameters
        }
    }
}
