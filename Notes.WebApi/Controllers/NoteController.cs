using AutoMapper;
using MediatR;
using Notes.Application.Commands.Create;
using Notes.Controllers;
using Notes.Domain.Models;
using Notes.WebApi.DtoModels;

namespace Notes.WebApi.Controllers
{
    public class NoteController : ControllerGeneric<Note, DtoNote, CreateNoteCommand>
    {
        public NoteController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
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
