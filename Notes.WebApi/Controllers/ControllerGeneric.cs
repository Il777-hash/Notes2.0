using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Commands.Delete;
using Notes.Application.Commands.Get;
using Notes.Application.Commands.GetAll;
using Notes.Domain.Models;

namespace Notes.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public abstract class ControllerGeneric<TEntity, TCreateCommand> : ControllerBase
        where TEntity : Entity
    {
        protected IMediator _mediator;

        protected ControllerGeneric(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> Create(TCreateCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete([FromBody] Guid id)
        {
            var command = new DeleteGenericCommand<TEntity>() { Id = id };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<ActionResult> Update([FromBody] Guid id, TCreateCommand command)
        {

        }

        [HttpPost("get-all")]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            var command = new GetAllGenericCommand<TEntity>();
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("get")]
        public async Task<ActionResult<TEntity>> GetOne([FromBody] Guid id)
        {
            var command = new GetOneGenericCommand<TEntity>() { Id = id };
            return Ok(await _mediator.Send(command));
        }
    }
}
