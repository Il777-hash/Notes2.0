using MediatR;
using Notes.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Notes.Application.Commands.Delete
{
    public class DeleteGenericCommand<T> : IRequest
        where T : Entity
    {
        [Required]
        public Guid Id { get; set; }
    }
}
