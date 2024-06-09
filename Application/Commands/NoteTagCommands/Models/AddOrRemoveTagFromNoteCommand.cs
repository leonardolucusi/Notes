namespace Notes.Application.Commands.NoteTagCommands.Models
{
    public class AddOrRemoveTagFromNoteCommand
    {
        public int TagId { get; set; }
        public int NoteId { get; set; }
    }
}
