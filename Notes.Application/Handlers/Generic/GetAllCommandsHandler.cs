using MediatR;
using Notes.Application.Commands.GetAll;
using Notes.Application.Interfaces;
using Notes.Domain.Models;

namespace Notes.Application.Handlers.Generic
{
    public class GetAllCommandsHandler<T> : BaseCommandHandler<T>, IRequestHandler<GetAllGenericCommand<T>, IEnumerable<T>>
        where T : Entity
    {
        public GetAllCommandsHandler(IRepository<T> repositiryContext) : base(repositiryContext)
        {
        }

        public async Task<IEnumerable<T>> Handle(GetAllGenericCommand<T> request, CancellationToken cancellationToken)
        {
            return await _repositoryContext.GetAll();
        }
    }
}
