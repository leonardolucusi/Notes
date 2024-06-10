using Notes.Application.Commands.NoteCommands.Models;
using Notes.Domain.Entities;
using Notes.Domain.Repositories;

namespace Notes.Application.Commands.NoteCommands.Handlers
{
    public class CreateNoteHandler
    {
        private readonly INoteCommandRepository _noteRepository;
        private readonly ITagRepository _tagRepository;

        public CreateNoteHandler(INoteCommandRepository noteRepository, ITagRepository tagRepository)
        {
            _noteRepository = noteRepository;
            _tagRepository = tagRepository;

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
                var tags = await _tagRepository.GetTagsByIdsAsync(command.TagIds);
                foreach (var tag in tags)
                {
                    note.NoteTags?.Add(new NoteTag { Note = note, Tag = tag });
                }

            }
            await _noteRepository.AddNoteAsync(note);
        }
    }
}
