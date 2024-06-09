namespace Notes.Application.Commands.NoteTagCommands.Models
{
    public class AddTagToNoteCommand
    {
        public int TagId { get; set; }
        public int NoteId { get; set; }
    }
}
