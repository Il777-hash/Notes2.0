using MediatR;
using Notes.Domain.Models;

namespace Notes.Application.Interfaces
{
    public interface IRepository<T>
    {

        public Task<Guid> Create(T entity);
        public Task<Unit> Delete(Guid id);
        public Task<Unit> Update(Guid id, T entity);
        public Task<T> GetOne(Guid id);
        public Task<IEnumerable<T>> GetAll();
        public Task<Tag> GetOrCreateTag(string nameTag);
    }
}
