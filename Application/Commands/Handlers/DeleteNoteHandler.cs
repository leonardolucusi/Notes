using Notes.Application.Commands.Models;
using Notes.Domain.Repositories;

namespace Notes.Application.Commands.Handlers
{
    public class DeleteNoteHandler
    {
        private readonly INoteCommandRepository _noteRepository;

        public DeleteNoteHandler(INoteCommandRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task Handle(DeleteNoteCommand command)
        {
            await _noteRepository.DeleteNoteAsync(command.Id);
        }
    }
}
