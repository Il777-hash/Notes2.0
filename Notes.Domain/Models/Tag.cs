namespace Notes.Domain.Models
{
    public class Tag : Entity
    {
        public string Name { get; set; }
        public List<Note> Notes { get; }
        public List<Reminder> Reminders { get; }
    }
}
