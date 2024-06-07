using Notes.Application.Commands.Models;
using Notes.Domain.Repositories;

namespace Notes.Application.Commands.Handlers
{
    public class DeleteNoteHandler
    {
        private readonly INoteRepository _noteRepository;

        public DeleteNoteHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task Handle(DeleteNoteCommand deleteNoteCommand)
        {
            await _noteRepository.DeleteNoteAsync(deleteNoteCommand.Id);
        }
    }
}
