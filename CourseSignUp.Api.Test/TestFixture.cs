using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace CourseSignUp.Api.Test
{
    public class TestFixture<TStartup> : IDisposable where TStartup : class
    {
        private readonly TestServer server;
        public TestFixture()
        {
            var builder = new WebHostBuilder().UseStartup<TStartup>();
            server = new TestServer(builder);

            Client = server.CreateClient();
            Client.BaseAddress = new Uri("http://localhost:53620/");
        }

        public HttpClient Client { get; }

        public void Dispose()
        {
            Client.Dispose();
            server.Dispose();
        }
    }
}
