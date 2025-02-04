﻿namespace Notes.Domain.Models
{
    public class Tag : Entity
    {
        public string Name { get; set; } = string.Empty;
        public List<Note> Notes { get; set; } = new List<Note>();
        public List<Reminder> Reminders { get; set; } = new List<Reminder>();
    }
}
