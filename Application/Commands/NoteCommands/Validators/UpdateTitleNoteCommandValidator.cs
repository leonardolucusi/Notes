using FluentValidation;
using Notes.Application.Commands.NoteCommands.Models;

namespace Notes.Application.Commands.NoteCommands.Validators
{
    public class UpdateTitleNoteCommandValidator : AbstractValidator<UpdateNoteTitleCommand>
    {
        public UpdateTitleNoteCommandValidator()
        {
            RuleFor(note => note.Title)
               .ValidateTitle();
        }
    }
}
