using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain.Models;

namespace Notes.Persistence
{
    public class Repository<T> : IRepository<T>
        where T : Entity
    {
        private readonly INotesDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public Repository(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
            var dbContextType = _dbContext.GetType();
            var dbSetOfItemProperty = dbContextType.GetProperties().First(property => property.PropertyType == typeof(DbSet<T>));
            _dbSet = (DbSet<T>)dbSetOfItemProperty.GetValue(_dbContext);
        }

        public async Task<Guid> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return entity.Id;
        }

        public async Task<Unit> Delete(Guid id)
        {
            var intity = await GetOne(id);
            _dbSet.Remove(intity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return Unit.Value;
        }

        public async Task<T> GetOne(Guid id)
        {
            var result = await _dbSet.FirstOrDefaultAsync(entity => entity.Id == id, CancellationToken.None);
            if (result is null) throw new NotFoundException(nameof(T), id);
            return result;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToArrayAsync();//todo: проблема с производительностью
        }

        public async Task<Unit> Update(Guid id, T entity)
        {
            var dbEntity = await GetOne(id);
            foreach (var property in entity.GetType().GetProperties().Where(property => property.Name != "Id"))
            {
                property.SetValue(dbEntity, property.GetValue(entity));
            }
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return Unit.Value;
        }
    }
}
