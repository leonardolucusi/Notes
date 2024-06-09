using System.Diagnostics.Contracts;

namespace Notes.Application.Commands.Models
{
    public class UpdateNoteContentCommand
    {
        public int Id { get; set; }
        public string? Content { get; set; }
    }
}
