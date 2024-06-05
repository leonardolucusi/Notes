namespace Notes.Domain.DTO
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public ICollection<TagDTO>? Tags { get; set; }
    }
}
