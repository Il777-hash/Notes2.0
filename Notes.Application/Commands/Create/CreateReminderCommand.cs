using MediatR;
using Notes.Domain.Models;

namespace Notes.Application.Commands.Create
{
    public class CreateReminderCommand : CreateItemCommand<Reminder>, IRequest<Guid>
    {
        public DateTime AlertDate { get; set; }
    }
}
