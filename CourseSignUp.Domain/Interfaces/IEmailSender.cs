using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseSignUp.Domain.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string from, string to, string cc, string subject, string body);
    }
}
