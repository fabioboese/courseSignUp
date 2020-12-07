using CourseSignUp.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseSignUp.Domain.Interfaces
{
    public interface IRepository
    {
        Task<T> GetByIdAsync<T>(string id) where T : BaseEntity, IAggregateRoot;
        Task<List<T>> ListAsync<T>() where T : BaseEntity, IAggregateRoot;
        Task<List<T>> ListAsync<T>(Func<T, bool> predicate) where T : BaseEntity, IAggregateRoot;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
        Task UpdateAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
        Task DeleteAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
    }
}
