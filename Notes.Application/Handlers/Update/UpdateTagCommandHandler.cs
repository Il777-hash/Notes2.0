using MediatR;
using Notes.Application.Commands.Update;
using Notes.Application.Interfaces;
using Notes.Domain.Models;

namespace Notes.Application.Handlers.Update
{
    public class UpdateTagCommandHandler : BaseCommandHandler<Tag>, IRequestHandler<UpdateTagCommand>
    {
        public UpdateTagCommandHandler(IRepository<Tag> repositiryContext) : base(repositiryContext)
        {
        }

        public async Task Handle(UpdateTagCommand request, CancellationToken cancellationToken)
        {
            Tag tag = new Tag
            {
                Name = request.Name
            };
            await _repositoryContext.Update(tag);
            return;
        }
    }
}
