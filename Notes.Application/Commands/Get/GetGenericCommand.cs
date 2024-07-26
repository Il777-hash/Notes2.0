using MediatR;
using Notes.Domain.Models;

namespace Notes.Application.Commands.Get
{
    public class GetGenericCommand<T> : IRequest<T>
        where T : Entity
    {
        public Guid Id { get; set; }
    }
}
