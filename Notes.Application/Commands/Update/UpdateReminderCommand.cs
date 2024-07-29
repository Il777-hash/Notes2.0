using Notes.Domain.Models;

namespace Notes.Application.Commands.Update
{
    public class UpdateReminderCommand : UpdateItemCommand<Reminder>
    {
        public DateTime AlertDate { get; set; }
    }
}
