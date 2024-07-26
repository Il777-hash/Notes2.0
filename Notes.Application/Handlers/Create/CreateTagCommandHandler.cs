using MediatR;
using Notes.Application.Commands.Create;
using Notes.Application.Interfaces;
using Notes.Domain.Models;

namespace Notes.Application.Handlers.Create
{
    public class CreateTagCommandHandler : BaseCommandHandler<Tag>, IRequestHandler<CreateTagCommand, Guid>
    {
        public CreateTagCommandHandler(IRepository<Tag> repositiryContext) : base(repositiryContext)
        {
        }

        public async Task<Guid> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            Tag tag = new Tag
            {
                Name = request.Name
            };
            return await _repositoryContext.Create(tag);
        }
    }
}
