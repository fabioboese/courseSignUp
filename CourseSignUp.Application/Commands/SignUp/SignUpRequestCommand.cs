using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CourseSignUp.Domain.Interfaces;
using Newtonsoft.Json;

namespace CourseSignUp.Application.Commands.SignUp
{
    class SignUpRequestCommand : ISignUpRequestCommand
    {
        private IMessageQueue _messageQueue;
        public SignUpRequestCommand(IMessageQueue messageQueue)
        {
            _messageQueue = messageQueue;
        }

        public async Task<string> ExecuteAsync(Domain.Entities.SignUp signUp)
        {
            await _messageQueue.EnqueueAsync(SignUpService.QUEUE_NAME, JsonConvert.SerializeObject(signUp));
            return "Signup request completed. Wait for confirmation";
        }
    }
}
