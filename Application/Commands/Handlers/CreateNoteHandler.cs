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

        public async Task Handler(CreateNoteCommand command)
        {
            var note = new Note
            {
                Title = command.Title,
                Content = command.Content,
                CreatedDate = command.CreatedDate,
                LastModified = command.LastModified,
                IsArchived = command.IsArchived,
                IsFavorite = command.IsFavorite,
            };
        }
    }
}
