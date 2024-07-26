using MediatR;
using Notes.Domain.Models;

namespace Notes.Application.Commands.Delete
{
    public class DeleteGenericCommand<T> : IRequest
        where T : Entity
    {
        public Guid Id { get; set; }
    }
}
