using MediatR;
using Notes.Application.Commands.Get;
using Notes.Application.Interfaces;
using Notes.Domain.Models;

namespace Notes.Application.Handlers.Generic
{
    public class GetOneCommandHandler<T> : BaseCommandHandler<T>, IRequestHandler<GetOneGenericCommand<T>, T>
        where T : Entity
    {
        public GetOneCommandHandler(IRepository<T> repositiryContext) : base(repositiryContext)
        {
        }

        public async Task<T> Handle(GetOneGenericCommand<T> request, CancellationToken cancellationToken)
        {
            return await _repositoryContext.GetOne(request.Id);
        }
    }
}
