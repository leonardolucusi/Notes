using Notes.Application.Commands.Models;
using Notes.Domain.Entities;
using Notes.Domain.Repositories;

namespace Notes.Application.Commands.Handlers
{
    public class CreateNoteHandler
    {
        private readonly INoteRepository _noteRepository;
        private readonly ITagRepository _tagRepository;

        public CreateNoteHandler(INoteRepository noteRepository, ITagRepository tagRepository)
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

            if (command.TagIds != null && command.TagIds.Any())
            {
                var tags = await _tagRepository.GetTagsByIdsAsync(command.TagIds);
                foreach (var tag in tags)
                {
                    note.NoteTags.Add(new NoteTag { Note = note, Tag = tag });
                }
               
            }
            await _noteRepository.AddNoteAsync(note);
        }
    }
}
