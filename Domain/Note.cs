namespace Notes.Domain
{
    public class Note
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsArchived { get; set; }
        public bool IsFavorite { get; set; }

        public ICollection<NoteTag> NoteTags { get; set; }

        public Note()
        {
            CreatedDate = DateTime.Now;
            LastModified = DateTime.Now;
            NoteTags = new List<NoteTag>();
        }

        public void UpdateLastModified()
        {
            LastModified = DateTime.Now;
        }
    }
}
