using Notes.Application.Commands.NoteCommands.Models;
using Notes.Domain.Repositories.INoteRepository.CommandRepository;

namespace Notes.Application.Commands.NoteCommands.Handlers
{
    public class UpdateNoteTitleHandler
    {
        private readonly INoteUpdateTitleCommandRepository _noteUpdateTitleCommandRepository;

        public UpdateNoteTitleHandler(INoteUpdateTitleCommandRepository noteUpdateTitleCommandRepository)
        {
            _noteUpdateTitleCommandRepository = noteUpdateTitleCommandRepository;
        }

        public async Task Handle(UpdateNoteTitleCommand command)
        {
            if (command.Title is not null && command.Id > 0)
            {
                await _noteUpdateTitleCommandRepository.UpdateNoteTitleAsync(command.Id, command.Title);
            }
        }
    }
}
