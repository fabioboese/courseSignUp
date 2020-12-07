using CourseSignUp.Domain.Core;
using CourseSignUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseSignUp.Infrastructure.InMemoryRepository
{
    public class MemoryRepository : IRepository
    {
        private readonly List<object> entities = new List<object>();

        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity, IAggregateRoot
        {
            await Task.Run(() => entities.Add(entity));
            return entity;
        }

        public async Task DeleteAsync<T>(T entity) where T : BaseEntity, IAggregateRoot
        {
            await Task.Run(() => entities.Remove(entity));
        }

        public async Task<T> GetByIdAsync<T>(string id) where T : BaseEntity, IAggregateRoot
        {
            T entity = null;
            await Task.Run(() => entity = entities.OfType<T>().Where(x => x.Id == id).SingleOrDefault());
            return entity;
        }

        public async Task<List<T>> ListAsync<T>() where T : BaseEntity, IAggregateRoot
        {
            List<T> list = null;
            await Task.Run(() => list = entities.OfType<T>().ToList());
            return list;
        }

        public async Task<List<T>> ListAsync<T>(Func<T, bool> predicate) where T : BaseEntity, IAggregateRoot
        {
            List<T> list = null;
            await Task.Run(() => list = entities.OfType<T>().Where(predicate).ToList());
            return list;
        }

        public async Task UpdateAsync<T>(T entity) where T : BaseEntity, IAggregateRoot
        {
            await Task.Run(() =>
            {
                entities.Remove(entity);
                entities.Add(entity);
            });
        }
    }
}
