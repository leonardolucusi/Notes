using Notes.Application.Commands.NoteCommands.Models;
using Notes.Domain.Repositories.INoteRepository.CommandRepository;

namespace Notes.Application.Commands.NoteCommands.Handlers
{
    public class UpdateNoteIsFavoriteHandler
    {
        private readonly INoteUpdateIsFavoriteCommandRepository _noteUpdateIsFavoriteCommandRepository;

        public UpdateNoteIsFavoriteHandler(INoteUpdateIsFavoriteCommandRepository noteUpdateIsFavoriteCommandRepository)
        {
            _noteUpdateIsFavoriteCommandRepository = noteUpdateIsFavoriteCommandRepository;
        }

        public async Task Handle(UpdateNoteIsFavoriteCommand command)
        {
            if (command is not null)
            {
                await _noteUpdateIsFavoriteCommandRepository.UpdateIsFavoriteAsync(command.Id, command.IsFavorite);
            }
        }
    }
}
