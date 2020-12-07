using CourseSignUp.Domain.Core;
using CourseSignUp.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Domain.Notifications
{
    public class SignUpCompletedNotification : INotification
    {
        public SignUp SignUp { get; set; }

        public SignUpCompletedNotification(SignUp signUpCompleted)
        {
            this.SignUp = signUpCompleted;
        }

    }
}
