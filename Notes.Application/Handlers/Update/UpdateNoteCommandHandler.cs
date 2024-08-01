using MediatR;
using Notes.Application.Commands.Update;
using Notes.Application.Interfaces;
using Notes.Domain.Models;

namespace Notes.Application.Handlers.Update
{
    public class UpdateNoteCommandHandler : BaseCommandHandler<Note>, IRequestHandler<UpdateNoteCommand>
    {
        public UpdateNoteCommandHandler(IRepository<Note> repositiryContext) : base(repositiryContext)
        {
        }

        public async Task Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            Note note = new Note //todo: automapper
            {
                Id = request.Id,
                Body = request.Body,
                Title = request.Title
            };
            foreach (var tag in request.Tags)
            {
                note.AddTag(await _repositoryContext.GetOrCreateTag(tag));
            }
            await _repositoryContext.Update(note);
            return;
        }

    }
}
