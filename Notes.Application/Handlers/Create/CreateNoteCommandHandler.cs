using MediatR;
using Notes.Application.Commands.Create;
using Notes.Application.Interfaces;
using Notes.Domain.Models;

namespace Notes.Application.Handlers.Create
{
    public class CreateNoteCommandHandler : BaseCommandHandler<Note>, IRequestHandler<CreateNoteCommand, Guid>
    {
        public CreateNoteCommandHandler(IRepository<Note> repositiryContext) : base(repositiryContext)
        {
        }

        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            Note note = Activator.CreateInstance<Note>();
            note.Body = request.Body;
            note.Title = request.Title;
            foreach (var tag in request.Tags)
            {
                note.AddTag(tag);
            }
            return await _repositoryContext.Create(note);
        }
    }
}
