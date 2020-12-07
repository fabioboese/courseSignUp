using CourseSignUp.Domain.Entities;
using CourseSignUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CourseSignUp.Application.Commands.CreateLecture
{
    public class CreateLecturerCommand : ICreateLecturerCommand
    {
        private IRepository _repository;
        public CreateLecturerCommand(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Lecturer> ExecuteAsync(Lecturer lecturer)
        {
            lecturer.Id = new Guid(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(lecturer.LectureName))).ToString();
            return await _repository.AddAsync(lecturer);
        }
    }
}
