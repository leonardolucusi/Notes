using FluentValidation;
using Notes.Application.Commands.NoteCommands.Models;

namespace Notes.Application.Commands.NoteCommands.Validators
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(note => note.Title)
              .ValidateTitle();

            RuleFor(note => note.IsArchived)
                .NotNull().WithMessage("IsArchived is required.");

            RuleFor(note => note.IsFavorite)
                .NotNull().WithMessage("IsFavorite is required.");
        }
    }
}
