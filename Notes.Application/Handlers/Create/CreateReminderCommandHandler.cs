﻿using MediatR;
using Notes.Application.Commands.Create;
using Notes.Application.Interfaces;
using Notes.Domain.Models;

namespace Notes.Application.Handlers.Create
{
    public class CreateReminderCommandHandler : BaseCommandHandler<Reminder>, IRequestHandler<CreateReminderCommand, Guid>
    {
        public CreateReminderCommandHandler(IRepository<Reminder> repositiryContext) : base(repositiryContext)
        {
        }

        public async Task<Guid> Handle(CreateReminderCommand request, CancellationToken cancellationToken)
        {
            var reminder = new Reminder
            {
                Title = request.Title,
                Body = request.Body,
                AlertDateTime = request.AlertDate
            };
            foreach (var tag in request.Tags)
            {
                reminder.AddTag(await _repositoryContext.GetOrCreateTag(tag));
            }
            return await _repositoryContext.Create(reminder);
        }
    }
}
