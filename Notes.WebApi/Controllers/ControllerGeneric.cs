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
    public abstract class ControllerGeneric<TEntity, TDtoEntity, TCreateCommand> : ControllerBase
        where TEntity : Entity
    {
        protected IMediator _mediator;
        protected IMapper _mapper;

        protected ControllerGeneric(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
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
        public async Task<ActionResult<IEnumerable<TDtoEntity>>> GetAll()
        {
            var command = new GetAllGenericCommand<TEntity>();
            var entityes = await _mediator.Send(command);
            return Ok(_mapper.Map<IEnumerable<TDtoEntity>>(entityes));
        }

        [HttpPost("get")]
        public async Task<ActionResult<TDtoEntity>> GetOne([FromBody] Guid id)
        {
            var command = new GetOneGenericCommand<TEntity>() { Id = id };
            var entity = await _mediator.Send(command);
            return Ok(_mapper.Map<TDtoEntity>(entity));
        }
    }
}
