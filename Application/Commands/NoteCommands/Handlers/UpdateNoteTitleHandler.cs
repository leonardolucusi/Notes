using FluentValidation;
using Notes.Application.Commands.NoteCommands.Models;
using Notes.Domain.Repositories.INoteRepository.CommandRepository;

namespace Notes.Application.Commands.NoteCommands.Handlers
{
    public class UpdateNoteTitleHandler
    {
        private readonly INoteUpdateTitleCommandRepository _noteUpdateTitleCommandRepository;
        private readonly IValidator<UpdateNoteTitleCommand> _validator;

        public UpdateNoteTitleHandler(INoteUpdateTitleCommandRepository noteUpdateTitleCommandRepository, IValidator<UpdateNoteTitleCommand> validator)
        {
            _noteUpdateTitleCommandRepository = noteUpdateTitleCommandRepository;
            _validator = validator;
        }

        public async Task Handle(UpdateNoteTitleCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);

            if (validationResult.IsValid is false)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException($"Validation failed: {errors}");
            }
            if (command.Title is not null && command.Id > 0)
            {
                await _noteUpdateTitleCommandRepository.UpdateNoteTitleAsync(command.Id, command.Title);
            }
        }
    }
}

