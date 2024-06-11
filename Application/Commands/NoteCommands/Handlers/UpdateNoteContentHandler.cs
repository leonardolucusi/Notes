using Notes.Application.Commands.NoteCommands.Models;
using Notes.Domain.Repositories.INoteRepository.CommandRepository;

namespace Notes.Application.Commands.NoteCommands.Handlers
{
    public class UpdateNoteContentHandler
    {
        private readonly INoteUpdateContentCommandRepository _noteUpdateContentCommandRepository;
        public UpdateNoteContentHandler(INoteUpdateContentCommandRepository noteUpdateContentCommandRepository)
        {
            _noteUpdateContentCommandRepository = noteUpdateContentCommandRepository;
        }

        public async Task Handle(UpdateNoteContentCommand command)
        {
            if (command.Content is not null && command.Id > 0)
            {
                await _noteUpdateContentCommandRepository.UpdateNoteContentAsync(command.Id, command.Content);
            }
        }
    }
}
