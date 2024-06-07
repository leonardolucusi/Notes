using Notes.Application.Commands.Models;
using Notes.Domain.Repositories;

namespace Notes.Application.Commands.Handlers
{
    public class UpdateNoteTitleHandler
    {
        private readonly INoteRepository _noteRepository;

        public UpdateNoteTitleHandler(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task Handle(UpdateNoteTitleCommand command)
        {
            await _noteRepository.UpdateNoteTitleAsync(command.Id, command.Title);
        }
    }
}
