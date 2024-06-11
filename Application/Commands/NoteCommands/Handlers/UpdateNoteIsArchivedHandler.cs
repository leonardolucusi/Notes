using Notes.Application.Commands.NoteCommands.Models;
using Notes.Domain.Repositories.INoteRepository.CommandRepository;

namespace Notes.Application.Commands.NoteCommands.Handlers
{
    public class UpdateNoteIsArchivedHandler
    {
        private readonly INoteUpdateIsArchivedCommandRepository _noteUpdateIsArchivedCommandRepository;

        public UpdateNoteIsArchivedHandler(INoteUpdateIsArchivedCommandRepository noteUpdateIsArchivedCommandRepository)
        {
            _noteUpdateIsArchivedCommandRepository = noteUpdateIsArchivedCommandRepository;
        }
        public async Task Handle(UpdateNoteIsArchivedCommand command)
        {
            await _noteUpdateIsArchivedCommandRepository.UpdateIsArchivedAsync(command.Id, command.IsArchived);
        }
    }
}
