using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseSignUp.Domain.Interfaces
{
    public interface IMessageQueue
    {
        Task EnqueueAsync(string queueName, string message);
        Task<string> DequeueAsync(string queueName);

    }
}
