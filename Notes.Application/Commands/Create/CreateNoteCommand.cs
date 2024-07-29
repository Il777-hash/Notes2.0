using MediatR;
using Notes.Domain.Models;

namespace Notes.Application.Commands.Create
{
    public class CreateNoteCommand : CreateItemCommand<Note>, IRequest<Guid>
    {

    }
}
