namespace Notes.Application.Commands.NoteCommands.Models
{
    public class UpdateNoteIsFavoriteCommand
    {
        public int Id { get; set; }
        public bool IsFavorite { get; set; }
    }
}
