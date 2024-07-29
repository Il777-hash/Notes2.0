using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain.Models;

namespace Notes.Persistence.EntityTypeConfigurations
{
    public class ReminderConfiguration : IEntityTypeConfiguration<Reminder>
    {
        public void Configure(EntityTypeBuilder<Reminder> builder)
        {
            builder.HasKey(reminder => reminder.Id);
            builder.HasIndex(reminder => reminder.Id);
            builder.HasMany(reminders => reminders.Tags).WithMany(tag => tag.Reminders);
        }
    }
}
