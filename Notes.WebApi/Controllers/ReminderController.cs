using MediatR;
using Notes.Application.Commands.Create;
using Notes.Controllers;
using Notes.Domain.Models;

namespace Notes.WebApi.Controllers
{
    public class ReminderController : ControllerGeneric<Reminder, CreateReminderCommand>
    {
        public ReminderController(IMediator mediator) : base(mediator)
        {
        }
    }
}
