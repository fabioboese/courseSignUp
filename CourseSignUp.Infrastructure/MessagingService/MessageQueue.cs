using CourseSignUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseSignUp.Infrastructure.MessagingService
{
    public class MessageQueue : IMessageQueue
    {
        Dictionary<string, Queue<string>> queues = new Dictionary<string, Queue<string>>();

        public async Task<string> DequeueAsync(string queueName)
        {
            string message = null;
            await Task.Run(() =>
            {
                if (!queues.ContainsKey(queueName))
                    queues.Add(queueName, new Queue<string>());

                if (queues[queueName].Count > 0)
                    message = queues[queueName].Dequeue();
            });
            return message;
        }

        public async Task EnqueueAsync(string queueName, string message)
        {
            await Task.Run(() =>
            {
                if (!queues.ContainsKey(queueName))
                    queues.Add(queueName, new Queue<string>());

                queues[queueName].Enqueue(message);
            });
        }
    }
}
