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
            Note note = Activator.CreateInstance<Note>();
            note.Id = request.Id;
            note.Body = request.Body;
            note.Title = request.Title;
            foreach (var tag in request.Tags)
            {
                note.AddTag(await _repositoryContext.GetOrCreateTag(tag));
            }
            await _repositoryContext.Update(note);
            return;
        }

    }
}
