using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Domain.Core
{
    public class BaseEntity
    {
        public string Id { get; set; }
        public List<BaseDomainEvent> Events { get; protected set; } = new List<BaseDomainEvent>();
    }
}
