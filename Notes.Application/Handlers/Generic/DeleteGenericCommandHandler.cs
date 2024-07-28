using MediatR;
using Notes.Application.Commands.Delete;
using Notes.Application.Interfaces;
using Notes.Domain.Models;

namespace Notes.Application.Handlers.Generic
{
    public class DeleteGenericCommandHandler<T> : BaseCommandHandler<T>, IRequestHandler<DeleteGenericCommand<T>>
        where T : Entity
    {
        public DeleteGenericCommandHandler(IRepository<T> repositiryContext) : base(repositiryContext)
        {
        }

        public async Task Handle(DeleteGenericCommand<T> request, CancellationToken cancellationToken)
        {
            await _repositoryContext.Delete(request.Id);
        }
    }
}
