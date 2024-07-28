﻿namespace Notes.Domain.Models
{
    public abstract class Item : Entity
    {
        internal List<Tag> tags = new List<Tag>();

        public string Title { get; set; }
        public string Body { get; set; }

        public IReadOnlyCollection<Tag> Tags => tags;
        public string[] TagNames => tags.Select(tag => tag.Name).ToArray();

        public void AddTag(Tag tag)
        {
            tags.Add(tag);
        }
    }
}
