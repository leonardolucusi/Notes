using FluentValidation;
using Notes.Application.Commands.NoteCommands.Models;
using Notes.Domain.Entities;
using Notes.Domain.Repositories.INoteRepository.CommandRepository;
using Notes.Domain.Repositories.ITagRepository.ITagQueryRepository.ITagQueryRepository;

namespace Notes.Application.Commands.NoteCommands.Handlers
{
    public class CreateNoteHandler
    {
        private readonly INoteAddComandRepository _noteAddComandRepository;
        private readonly ITagByIdQueryRepository _tagByIdQueryRepository;
        private readonly IValidator<CreateNoteCommand> _validator;

        public CreateNoteHandler(INoteAddComandRepository noteAddComandRepository, ITagByIdQueryRepository tagByIdQueryRepository, IValidator<CreateNoteCommand> validator)
        {
            _noteAddComandRepository = noteAddComandRepository;
            _tagByIdQueryRepository = tagByIdQueryRepository;
            _validator = validator;
        }

        public async Task Handle(CreateNoteCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);

            if (validationResult.IsValid is false)
            {
                var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
                throw new ArgumentException($"Validation failed: {errors}");
            }

            Note note = new Note
            {
                Title = command.Title,
                Content = command.Content,
                IsArchived = command.IsArchived,
                IsFavorite = command.IsFavorite,
            };

            if (command.TagIds is not null && command.TagIds.Any())
            {
                var tags = await _tagByIdQueryRepository.GetTagsByIdsAsync(command.TagIds);
                foreach (var tag in tags)
                {
                    note.NoteTags?.Add(new NoteTag { Note = note, Tag = tag });
                }
            }
            await _noteAddComandRepository.AddNoteAsync(note);
        }
    }
}
