using Notes.Application.Commands.NoteCommands.Models;
using Notes.Domain.Entities;
using Notes.Domain.Repositories.INoteRepository.CommandRepository;
using Notes.Domain.Repositories.ITagRepository.ITagQueryRepository.ITagQueryRepository;

namespace Notes.Application.Commands.NoteCommands.Handlers
{
    public class CreateNoteHandler
    {
        private readonly INoteCommandRepository _noteCommandRepository;
        private readonly ITagByIdQueryRepository _tagQueryRepository;

        public CreateNoteHandler(INoteCommandRepository noteCommandRepository, ITagByIdQueryRepository tagQueryRepository)
        {
            _noteCommandRepository = noteCommandRepository;
            _tagQueryRepository = tagQueryRepository;
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
                var tags = await _tagQueryRepository.GetTagsByIdsAsync(command.TagIds);
                foreach (var tag in tags)
                {
                    note.NoteTags?.Add(new NoteTag { Note = note, Tag = tag });
                }
            }
            await _noteCommandRepository.AddNoteAsync(note);
        }
    }
}
