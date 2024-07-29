using Microsoft.EntityFrameworkCore;
using Notes.Application.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain.Models;

namespace Notes.Persistence
{
    public class TagRepository : Repository<Tag>
    {
        public TagRepository(INotesDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Tag> GetOne(Guid id)
        {
            var result = await _dbSet.FirstOrDefaultAsync(entity => entity.Id == id);
            if (result is null) throw new NotFoundException(nameof(Tag), id);
            return result;
        }

        public override async Task<IEnumerable<Tag>> GetAll()
        {
            return await _dbSet.ToArrayAsync();//todo: проблема с производительностью
        }
    }
}
