using FluentValidation;
using Notes.Application.Commands.NoteCommands.Models;

namespace Notes.Application.Commands.NoteCommands.Validators
{
    public class UpdateTitleNoteCommandValidator : AbstractValidator<UpdateNoteTitleCommand>
    {
        public UpdateTitleNoteCommandValidator()
        {
            RuleFor(note => note.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(10).WithMessage("Title must be at most 10 characters long.");
        }
    }
}
