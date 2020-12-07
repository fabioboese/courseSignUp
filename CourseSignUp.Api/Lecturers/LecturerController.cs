using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CourseSignUp.Application.Commands.CreateLecture;
using CourseSignUp.Domain.Entities;
using CourseSignUp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseSignUp.Api.Lecturers
{
    [ApiController, Route("[controller]")]
    public class LecturersController : ControllerBase
    {
        private IRepository _repository;
        private ICreateLecturerCommand _createLecturerCommand;
        public LecturersController(IRepository repository, ICreateLecturerCommand createLecturerCommand)
        {
            _repository = repository;
            _createLecturerCommand = createLecturerCommand;
        }

        [HttpPost, Route("create")]
        public async Task<IActionResult> Post([FromBody]CreateLecturerDto createLecturerDto)
        {
            await _createLecturerCommand.ExecuteAsync(new Lecturer
            {
                LectureName = createLecturerDto.Name
            });
            return Ok();
        }
    }
}