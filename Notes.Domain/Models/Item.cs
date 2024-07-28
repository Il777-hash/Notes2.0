﻿namespace Notes.Domain.Models
{
    public abstract class Item : Entity
    {
        internal List<Tag> tags = new List<Tag>();

        public string Title { get; set; }
        public string Body { get; set; }

        public IReadOnlyCollection<Tag> Tags => tags;

        public void AddTag(string nameTag)
        {
            var tag = new Tag { Name = nameTag };
            tags.Add(tag);
        }
    }
}
