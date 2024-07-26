using MediatR;
using Notes.Domain.Models;

namespace Notes.Application.Commands.Create
{
    public class CreateReminderCommand : CreateGenericCommand<Reminder>, IRequest<Guid>
    {
        public DateTime AlertDate { get; set; }
    }
}
