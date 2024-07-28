using MediatR;
using Notes.Application.Commands.Create;
using Notes.Controllers;
using Notes.Domain.Models;

namespace Notes.WebApi.Controllers
{
    public class NoteController : ControllerGeneric<Note, CreateNoteCommand>
    {
        public NoteController(IMediator mediator) : base(mediator)
        {
        }

        //[HttpPost("create")]
        //public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteCommand command)
        //{
        //    var id = await _mediator.Send(command);
        //    return Ok(id);
        //}
    }
}
