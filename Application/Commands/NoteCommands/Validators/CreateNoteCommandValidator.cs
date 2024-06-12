using FluentValidation;
using Notes.Application.Commands.NoteCommands.Models;

namespace Notes.Application.Commands.NoteCommands.Validators
{
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            RuleFor(note => note.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(10).WithMessage("Title must be at most 10 characters long.");

            RuleFor(note => note.IsArchived)
                .NotNull().WithMessage("IsArchived is required.");

            RuleFor(note => note.IsFavorite)
                .NotNull().WithMessage("IsFavorite is required.");
        }
    }
}
