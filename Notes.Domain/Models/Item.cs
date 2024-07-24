namespace Notes.Domain.Models
{
    public class Item
    {
        internal List<Tag> tags = new List<Tag>();

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public IReadOnlyCollection<Tag> Tags => tags;

        public void AddTag(Tag tag)
        {
            tags.Add(tag);
        }
    }
}
