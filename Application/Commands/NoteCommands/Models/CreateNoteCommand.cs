namespace Notes.Application.Commands.NoteCommands.Models
{
    public class CreateNoteCommand
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public bool IsArchived { get; set; }
        public bool IsFavorite { get; set; }
        public IEnumerable<int>? TagIds { get; set; }
    }
}
