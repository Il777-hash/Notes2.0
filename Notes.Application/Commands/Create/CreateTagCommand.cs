using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Notes.Application.Commands.Create
{
    public class CreateTagCommand : IRequest<Guid>
    {
        [Required]
        public string Name { get; set; }
    }
}
