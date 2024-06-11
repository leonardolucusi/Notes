using Notes.Application.Commands.NoteCommands.Models;
using Notes.Domain.Repositories.INoteRepository.CommandRepository;

namespace Notes.Application.Commands.NoteCommands.Handlers
{
    public class DeleteNoteHandler
    {
        private readonly INoteDeleteCommandRepository _noteDeleteCommandRepository;

        public DeleteNoteHandler(INoteDeleteCommandRepository noteDeleteCommandRepository)
        {
            _noteDeleteCommandRepository = noteDeleteCommandRepository;
        }

        public async Task Handle(DeleteNoteCommand command)
        {
            await _noteDeleteCommandRepository.DeleteNoteAsync(command.Id);
        }
    }
}
