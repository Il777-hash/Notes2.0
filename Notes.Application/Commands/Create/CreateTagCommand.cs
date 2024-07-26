using MediatR;

namespace Notes.Application.Commands.Create
{
    public class CreateTagCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
