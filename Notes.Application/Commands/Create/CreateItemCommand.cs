using MediatR;
using Notes.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Notes.Application.Commands.Create
{
    public class CreateItemCommand<T> : IRequest<Guid>
        where T : Item
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new List<string>();
    }
}
