using MediatR;
using Notes.Application.Commands.Get;
using Notes.Application.Interfaces;
using Notes.Domain.Models;

namespace Notes.Application.Handlers.Generic
{
    public class GetCommandHandler<T> : BaseCommandHandler<T>, IRequestHandler<GetGenericCommand<T>, T>
        where T : Entity
    {
        public GetCommandHandler(IRepository<T> repositiryContext) : base(repositiryContext)
        {
        }

        public async Task<T> Handle(GetGenericCommand<T> request, CancellationToken cancellationToken)
        {
            return await _repositoryContext.Get(request.Id);
        }
    }
}
