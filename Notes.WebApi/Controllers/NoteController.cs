using Microsoft.AspNetCore.Mvc;
using Notes.Application.Commands.Create;
using Notes.Application.Commands.Delete;
using Notes.Controllers;
using Notes.Domain.Models;

namespace Notes.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("[controller]")]

    public class NoteController : ControllerMain
    {
        [HttpPost("create")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteCommand command)
        {
            var id = await Mediator.Send(command);
            return Ok(id);
        }
        [HttpPost("delete")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteGenericCommand<Note>() { Id = id };
            await Mediator.Send(command);
            return Ok();
        }
    }
}
