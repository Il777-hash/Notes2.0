using MediatR;

namespace Notes.Application.Interfaces
{
    public interface IRepository<T>
    {

        public Task<Guid> Create(T item);
        public Task<Unit> Delete(Guid id);
        public Task<Guid> Update(T item);
        public Task<T> GetOne(Guid id);
        public Task<IEnumerable<T>> GetAll();
    }
}
