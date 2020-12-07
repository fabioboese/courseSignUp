using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace CourseSignUp.Api.Test
{
    public class IntegrationTests : IClassFixture<TestFixture<CourseSignUp.Api.Startup>>, ITestCaseOrderer
    {
        private HttpClient client;
        public IntegrationTests(TestFixture<CourseSignUp.Api.Startup> fixture)
        {
            client = fixture.Client;
            client.DefaultRequestHeaders
                .Accept
                .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Theory, TestPriority(1)]
        [InlineData("3-Axis Machining with Autodesk Fusion 360 (Autodesk)")]    //Id: 92f97354-d8be-085b-8faa-54e33a43baac
        [InlineData("Brand & Content Marketing (IE Business School)")]          //Id: 976ecca8-acfe-80db-7fc5-ca90d1812658
        [InlineData("G Suite Security (Google Cloud)")]                         //Id: 2cbd25f4-40d9-d4b3-e3bf-a13054cf2f0d
        public async Task CreateLecturer_ValidObject_Success(string Name)
        {
            // Arrange
            string json = JsonConvert.SerializeObject((new { Name = Name }));
            var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "/Lecturers/create");
            requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var responseMessage = await client.SendAsync(requestMessage);

            // Assert
            Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        [Theory, TestPriority(2)]
        [InlineData("Course 10 (Lecture 1)", "92f97354-d8be-085b-8faa-54e33a43baac", 10)]    //Id: e60e19be-ef88-66a2-b544-a384832159b9
        [InlineData("Course 11 (Lecture 1)", "92f97354-d8be-085b-8faa-54e33a43baac", 20)]    //Id: 9e3d106d-8e2b-d737-bb15-3a1ff9ac5593
        [InlineData("Course 12 (Lecture 1)", "92f97354-d8be-085b-8faa-54e33a43baac", 30)]    //Id: d2d92be8-6240-6f84-fb71-e8436667f67a
        public async Task CreateCourse_ValidObject_Success(string Name, string LecturerId, int Capacity)
        {
            // Arrange
            string json = JsonConvert.SerializeObject((new { Name = Name, LecturerId = LecturerId, Capacity = Capacity }));
            var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "/Courses/create");
            requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var responseMessage = await client.SendAsync(requestMessage);

            // Assert
            Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
        }

        [Theory, TestPriority(3)]
        [InlineData("e60e19be-ef88-66a2-b544-a384832159b9", 25)]    //Id: e60e19be-ef88-66a2-b544-a384832159b9
        [InlineData("9e3d106d-8e2b-d737-bb15-3a1ff9ac5593", 40)]    //Id: 9e3d106d-8e2b-d737-bb15-3a1ff9ac5593
        [InlineData("d2d92be8-6240-6f84-fb71-e8436667f67a", 100)]    //Id: d2d92be8-6240-6f84-fb71-e8436667f67a
        public async Task SignUp_ValidObject_Success(string CourseId, int students)
        {
            Random rnd = new Random();
            for (int i = 1; i <= students; i++)
            {
                // Arrange
                string json = JsonConvert.SerializeObject((new
                {
                    CourseId = CourseId,
                    Student = new
                    {
                        Email = $"student{i}@mail.com",
                        Name = $"Student {i}",
                        DateOfBirth = DateTime.Today.AddDays(-rnd.Next(5475, 23725))
                    }
                }));
                
                var requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "/Courses/sign-up");
                requestMessage.Content = new StringContent(json, Encoding.UTF8, "application/json");

                // Act
                var responseMessage = await client.SendAsync(requestMessage);

                // Assert
                Assert.Equal(HttpStatusCode.OK, responseMessage.StatusCode);
            }
        }


        // source: https://hamidmosalla.com/2018/08/16/xunit-control-the-test-execution-order/
        public IEnumerable<TTestCase> OrderTestCases<TTestCase>(IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
        {
            var sortedMethods = new SortedDictionary<int, List<TTestCase>>();

            foreach (TTestCase testCase in testCases)
            {
                int priority = 0;

                foreach (IAttributeInfo attr in testCase.TestMethod.Method.GetCustomAttributes((typeof(TestPriorityAttribute).AssemblyQualifiedName)))
                    priority = attr.GetNamedArgument<int>("Priority");

                GetOrCreate(sortedMethods, priority).Add(testCase);
            }

            foreach (var list in sortedMethods.Keys.Select(priority => sortedMethods[priority]))
            {
                list.Sort((x, y) => StringComparer.OrdinalIgnoreCase.Compare(x.TestMethod.Method.Name, y.TestMethod.Method.Name));
                foreach (TTestCase testCase in list) yield return testCase;

            }
        }

        static TValue GetOrCreate<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TKey key)
            where TValue : new()
        {
            TValue result;

            if (dictionary.TryGetValue(key, out result)) return result;

            result = new TValue();
            dictionary[key] = result;

            return result;
        }
    }

}
