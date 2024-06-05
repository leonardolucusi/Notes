﻿namespace Notes.Domain.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<NoteTag>? NoteTags { get; set; }
        public Tag()
        {
            NoteTags = new List<NoteTag>();
        }
    }
}
