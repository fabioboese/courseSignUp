using CourseSignUp.Application.Commands.CreateCourse;
using CourseSignUp.Application.Commands.SignUp;
using CourseSignUp.Application.Queries;
using CourseSignUp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CourseSignUp.Api.Courses
{
    [ApiController, Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        private ICreateCourseCommand _createCourseCommand;
        private IGetCoursesCommand _getCoursesCommand;
        private ISignUpRequestCommand _signUpRequestCommand;

        public CoursesController(ICreateCourseCommand createCourseCommand, IGetCoursesCommand getCoursesCommand, ISignUpRequestCommand signUpRequestCommand)
        {
            _createCourseCommand = createCourseCommand;
            _getCoursesCommand = getCoursesCommand;
            _signUpRequestCommand = signUpRequestCommand;
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var entity = await _getCoursesCommand.ExecuteAsync(id);
            if (entity == null)
                return Ok(new CourseDto
                {
                    Id = entity.Id,
                    Capacity = entity.Capacity,
                    NumberOfStudents = entity.NumberOfStudents
                });
            else
                return NotFound();
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> Post([FromBody]CreateCourseDto createCourseDto)
        {
            await _createCourseCommand.ExecuteAsync(new Domain.Entities.Course
            {
                LecturerId = createCourseDto.LecturerId,
                Name = createCourseDto.Name,
                Capacity = createCourseDto.Capacity
            });
            return Ok();
        }

        [HttpPost, Route("sign-up")]
        public async Task<IActionResult> Post([FromBody] SignUpToCourseDto signUpToCourseDto)
        {
            await _signUpRequestCommand.ExecuteAsync(new Domain.Entities.SignUp
            {
                CourseId = signUpToCourseDto.CourseId,
                Student = new Domain.Entities.Student
                {
                    Email = signUpToCourseDto.Student.Email,
                    Name = signUpToCourseDto.Student.Name,
                    DateOfBirth = signUpToCourseDto.Student.DateOfBirth
                }
            });
            return Ok();
        }
    }
}
