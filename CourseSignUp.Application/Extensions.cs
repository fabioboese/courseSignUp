using CourseSignUp.Application.Commands.CreateCourse;
using CourseSignUp.Application.Commands.CreateLecture;
using CourseSignUp.Application.Commands.SignUp;
using CourseSignUp.Application.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Application
{
    public static class Extensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<ICreateCourseCommand, CreateCourseCommand>();
            services.AddSingleton<ICreateLecturerCommand, CreateLecturerCommand>();
            services.AddSingleton<ISignUpConfirmationCommand, SignUpConfirmationCommand>();
            services.AddSingleton<ISignUpRequestCommand, SignUpRequestCommand>();
            services.AddSingleton<IGetCoursesCommand, GetCoursesCommand>();
            services.AddSingleton<IGetStatisticsCommand, GetStatisticsCommand>();
            services.AddSingleton<ISignUpService, SignUpService>();
        }
    }
}
