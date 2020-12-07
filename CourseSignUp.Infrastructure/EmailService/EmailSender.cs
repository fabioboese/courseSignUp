using CourseSignUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CourseSignUp.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string from, string to, string cc, string subject, string body)
        {
            await Task.Run(() =>
            {
                Debug.Print($"Sending e-mail from {from} to {to}, copying {cc} with the subject \"{subject}\"");
            });
        }
    }
}
