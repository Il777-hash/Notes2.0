﻿namespace Notes.Domain.Models
{
    public abstract class Item : Entity
    {
        public List<Tag> Tags { get; set; } = new List<Tag>();

        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;

        public string[] TagNames => Tags.Select(tag => tag.Name).ToArray();

        public void AddTag(Tag tag)
        {
            Tags.Add(tag);
        }
    }
}
