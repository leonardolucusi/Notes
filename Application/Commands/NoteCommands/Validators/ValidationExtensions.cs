using FluentValidation;

namespace Notes.Application.Commands.NoteCommands.Validators
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> ValidateTitle<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(50).WithMessage("Title must be at most 50 characters long.");
        }
    }
}
