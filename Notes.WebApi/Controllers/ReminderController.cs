using AutoMapper;
using MediatR;
using Notes.Application.Commands.Create;
using Notes.Application.Commands.Update;
using Notes.Controllers;
using Notes.Domain.Models;
using Notes.WebApi.DtoModels;

namespace Notes.WebApi.Controllers
{
    public class ReminderController : ControllerGeneric<Reminder, DtoReminder, CreateReminderCommand, UpdateReminderCommand>
    {
        public ReminderController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
    }
}
