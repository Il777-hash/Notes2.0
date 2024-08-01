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
        protected readonly INotesDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public Repository(INotesDbContext dbContext)
        {
            _dbContext = dbContext;
            var dbContextType = _dbContext.GetType();
            var dbSetOfItemProperty = dbContextType.GetProperties().First(property => property.PropertyType == typeof(DbSet<T>));
            _dbSet = dbSetOfItemProperty.GetValue(_dbContext) as DbSet<T>;
        }

        public async Task<Guid> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return entity.Id;
        }

        public async Task<Unit> Delete(Guid id)
        {
            //var intity = await GetOne(id);
            //_dbSet.Remove(intity);
            //await _dbContext.SaveChangesAsync(CancellationToken.None);
            await _dbSet.Where(dbEntity => dbEntity.Id == id).ExecuteDeleteAsync();
            return Unit.Value;
        }

        public virtual async Task<T> GetOne(Guid id)
        {
            var result = await _dbSet.Include(nameof(Item.Tags)).FirstOrDefaultAsync(entity => entity.Id == id);
            if (result is null) throw new NotFoundException(typeof(T).Name, id);
            return result;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.Include(nameof(Item.Tags)).ToArrayAsync();//todo: проблема с производительностью
        }

        public async Task<Unit> Update(T entity)
        {
            var dbEntity = await GetOne(entity.Id);
            IEnumerable<System.Reflection.PropertyInfo> properties = entity.GetType().GetProperties().Where(property => property.CanWrite && property.Name != "Id");
            foreach (var property in properties)
            {
                property.SetValue(dbEntity, property.GetValue(entity));
            }
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            return Unit.Value;
        }

        public async Task<Tag> GetOrCreateTag(string nameTag)
        {
            var tag = await _dbContext.Tags.FirstOrDefaultAsync(tag => tag.Name == nameTag);

            return tag ?? new Tag() { Name = nameTag };
        }
    }
}
