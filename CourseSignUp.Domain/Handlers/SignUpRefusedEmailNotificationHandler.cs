using CourseSignUp.Domain.Interfaces;
using CourseSignUp.Domain.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignUp.Domain.Handlers
{
    public class SignUpRefusedEmailNotificationHandler : INotificationHandler<SignUpRefusedNotification>
    {
        private IEmailSender _emailSender;

        public SignUpRefusedEmailNotificationHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task Handle(SignUpRefusedNotification notification, CancellationToken cancellationToken)
        {
            var signUp = notification.SignUp;
            await _emailSender.SendEmailAsync(
                "noreply@chamaUniversity.com",
                signUp.Student.Email,
                "",
                $"SignUp Refused",
                $"Dear, {signUp.Student.Name}" +
                $"Sorry, but your sign up to the {signUp.CourseId} couldn't be cofirmed due to the maximum capacity has been reached!"); 
            // TODO: improve parameters
        }
    }
}
