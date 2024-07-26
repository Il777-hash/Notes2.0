using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Notes.Controllers
{

    public class ControllerMain : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    }
}
