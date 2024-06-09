using Notes.Application.Commands.Models;
using Notes.Domain.Repositories;

namespace Notes.Application.Commands.Handlers
{
    public class UpdateNoteContentHandler
    {
        private readonly INoteRepository _noteRepository;
        public UpdateNoteContentHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task Handle(UpdateNoteContentCommand command)
        {
            if (command.Content is not null && command.Id > 0)
            {
                await _noteRepository.UpdateNoteContentAsync(command.Id, command.Content);
            }
        }
    }
}
