using CourseSignUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Infrastructure.ApplicationServices
{
    public class SignUpService
    {
        private IRepository _repository;
        public SignUpService(IRepository repository)
        {
            _repository = repository;
        }

        
    }
}
