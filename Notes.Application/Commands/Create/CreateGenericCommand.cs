using MediatR;
using Notes.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Notes.Application.Commands.Create
{
    public class CreateGenericCommand<T> : IRequest<Guid>
        where T : Item
    {
        [Required]
        public string Title { get; set; }
        public string Body { get; set; }
        public List<Tag> Tags { get; set; } //todo: использовать название или Guid 
    }
}
