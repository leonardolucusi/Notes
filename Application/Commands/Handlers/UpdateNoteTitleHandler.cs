using Notes.Application.Commands.Models;
using Notes.Domain.Repositories;

namespace Notes.Application.Commands.Handlers
{
    public class UpdateNoteTitleHandler
    {
        private readonly INoteCommandRepository _noteRepository;

        public UpdateNoteTitleHandler(INoteCommandRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public async Task Handle(UpdateNoteTitleCommand command)
        {
            if (command.Title is not null && command.Id > 0)
            {
                await _noteRepository.UpdateNoteTitleAsync(command.Id, command.Title);
            }
        }
    }
}
