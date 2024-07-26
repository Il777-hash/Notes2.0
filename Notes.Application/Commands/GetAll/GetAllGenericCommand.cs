using MediatR;
using Notes.Domain.Models;

namespace Notes.Application.Commands.GetAll
{
    public class GetAllGenericCommand<T> : IRequest<IEnumerable<T>>
        where T : Entity
    {
    }
}
