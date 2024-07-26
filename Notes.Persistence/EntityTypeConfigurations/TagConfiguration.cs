using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain.Models;

namespace Notes.Persistence.EntityTypeConfigurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            //todo: связи многие ко многим
            builder.HasKey(tag => tag.Id);
            builder.HasIndex(tag => tag.Id);
            builder.HasIndex(tag => tag.Name).IsUnique();
        }
    }
}
