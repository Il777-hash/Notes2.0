using MediatR;
using Notes.Application.Commands.Update;
using Notes.Application.Interfaces;
using Notes.Domain.Models;

namespace Notes.Application.Handlers.Update
{
    public class UpdateReminderCommandHandler : BaseCommandHandler<Reminder>, IRequestHandler<UpdateReminderCommand>
    {
        public UpdateReminderCommandHandler(IRepository<Reminder> repositiryContext) : base(repositiryContext)
        {
        }

        public async Task Handle(UpdateReminderCommand request, CancellationToken cancellationToken)
        {
            var reminder = new Reminder
            {
                Id = request.Id,
                Title = request.Title,
                Body = request.Body,
                AlertDateTime = request.AlertDate
            };
            foreach (var tag in request.Tags)
            {
                reminder.AddTag(await _repositoryContext.GetOrCreateTag(tag));
            }
            await _repositoryContext.Update(reminder);
            return;
        }
    }
}
