using CourseSignUp.Domain.Entities;
using CourseSignUp.Domain.Handlers;
using CourseSignUp.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CourseSignUp.Application.Commands.SignUp
{
    public class SignUpService : ISignUpService
    {
        public const string QUEUE_NAME = "SIGNUP";

        private IMessageQueue _messageQueue;
        private IRepository _repository;
        private ISignUpConfirmationCommand _signUpConfirmationCommand;
        public SignUpService(IRepository repository, IMessageQueue messageQueue, ISignUpConfirmationCommand signUpConfirmationCommand)
        {
            _repository = repository;
            _messageQueue = messageQueue;
            _signUpConfirmationCommand = signUpConfirmationCommand;
        }

        public void Execute()
        {
            Thread newThread = new Thread(QueueMonitor);
            newThread.Start();
        }

        // Simulates service bus queue
        private void QueueMonitor()
        {
            Task.Run(async () =>
            {

                while (true)
                {
                    var msg = await _messageQueue.DequeueAsync(QUEUE_NAME);
                    if (msg == null)
                        Thread.Sleep(100);
                    else
                    {
                        // this shold be replaced by a call to Azure Function
                        var signUp = JsonConvert.DeserializeObject<Domain.Entities.SignUp>(msg);
                        await _signUpConfirmationCommand.ExecuteAsync(signUp);
                        Thread.Sleep(5);
                    }

                }
            });
        }



    }
}
