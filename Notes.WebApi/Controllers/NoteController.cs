using Microsoft.AspNetCore.Mvc;
using Notes.Application.Commands.Create;
using Notes.Controllers;

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
    }
}
