using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Notes.Application.Commands.Update
{
    public class UpdateTagCommand : IRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
