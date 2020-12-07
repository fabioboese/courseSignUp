using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Domain.Core
{
    public abstract class BaseDomainEvent : INotification
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
    }
}
