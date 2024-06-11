namespace Notes.Application.Commands.NoteCommands.Models
{
    public class UpdateNoteIsArchivedCommand
    {
        public int Id { get; set; }
        public bool IsArchived { get; set; }
    }
}
