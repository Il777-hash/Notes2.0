using MediatR;
using Notes.Application.Commands.Create;
using Notes.Controllers;
using Notes.Domain.Models;

namespace Notes.WebApi.Controllers
{
    public class TagController : ControllerGeneric<Tag, CreateTagCommand>
    {
        public TagController(IMediator mediator) : base(mediator)
        {
        }
    }
}
