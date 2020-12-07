using CourseSignUp.Domain.Interfaces;
using CourseSignUp.Infrastructure.EmailService;
using CourseSignUp.Infrastructure.InMemoryRepository;
using CourseSignUp.Infrastructure.MessagingService;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CourseSignUp.Infrastructure
{
    public static class Extensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IRepository, MemoryRepository>();
            services.AddSingleton<IMessageQueue, MessageQueue>();
            services.AddSingleton<IEmailSender, EmailSender>();
        }
    }
}
