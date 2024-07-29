using AutoMapper;
using MediatR;
using Notes.Application.Commands.Create;
using Notes.Controllers;
using Notes.Domain.Models;
using Notes.WebApi.DtoModels;

namespace Notes.WebApi.Controllers
{
    public class ReminderController : ControllerGeneric<Reminder, DtoReminder, CreateReminderCommand>
    {
        public ReminderController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
    }
}
