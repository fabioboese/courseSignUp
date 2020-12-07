using CourseSignUp.Domain.Entities;
using CourseSignUp.Domain.Interfaces;
using CourseSignUp.Domain.Notifications;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseSignUp.Application.Commands.SignUp
{
    class SignUpConfirmationCommand : ISignUpConfirmationCommand
    {
        private IRepository _repository;
        private IMediator _mediator;
        public SignUpConfirmationCommand(IRepository repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task ExecuteAsync(Domain.Entities.SignUp signUp)
        {
            var course = await _repository.GetByIdAsync<Course>(signUp.CourseId);
            if (course.NumberOfStudents < course.Capacity)
            {
                // calculate the age of the student
                var today = DateTime.Today;
                var age = today.Year - signUp.Student.DateOfBirth.Year;
                if (signUp.Student.DateOfBirth > today.AddYears(-age))
                    age -= 1;

                // set statistics data
                if (course.Statistics.MinAge > age)
                    course.Statistics.MinAge = age;

                if (course.Statistics.MaxAge < age)
                    course.Statistics.MaxAge = age;

                course.Statistics.SumAge += age;

                // increase the number of students
                course.NumberOfStudents += 1;

                // update data in repository
                await _repository.UpdateAsync(course);
                await _repository.AddAsync(signUp);

                // publish succesfully signup notification
                await _mediator.Publish(new SignUpCompletedNotification(signUp));
            }
            else
            {
                // publish refused signup notification
                await _mediator.Publish(new SignUpRefusedNotification(signUp));
            }
        }
    }
}
