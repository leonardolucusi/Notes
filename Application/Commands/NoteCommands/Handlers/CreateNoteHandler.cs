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

        public CreateNoteHandler(INoteAddComandRepository noteAddComandRepository, ITagByIdQueryRepository tagByIdQueryRepository)
        {
            _noteAddComandRepository = noteAddComandRepository;
            _tagByIdQueryRepository = tagByIdQueryRepository;
        }

        public async Task Handle(CreateNoteCommand command)
        {
            var note = new Note
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
