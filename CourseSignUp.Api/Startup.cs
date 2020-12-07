using CourseSignUp.Application;
using CourseSignUp.Application.Commands.SignUp;
using CourseSignUp.Domain;
using CourseSignUp.Domain.Core;
using CourseSignUp.Domain.Interfaces;
using CourseSignUp.Infrastructure;
using CourseSignUp.Infrastructure.InMemoryRepository;
using CourseSignUp.Infrastructure.MessagingService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CourseSignUp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddApplication();
            services.AddDomain();
            services.AddInfrastructure();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ApplicationServices.GetService<ISignUpService>().Execute();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
