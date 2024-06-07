namespace Notes.Application.Commands.Models
{
    public class CreateNoteCommand
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsArchived { get; set; }
        public bool IsFavorite { get; set; }
    }
}
