using MediatR;
using Notes.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Notes.Application.Commands.Update
{
    public class UpdateItemCommand<T> : IRequest
        where T : Item
    {
        [Required]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public List<string> Tags { get; set; }
    }
}
