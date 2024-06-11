using Notes.Application.Commands.NoteTagCommands.Models;
using Notes.Domain.Repositories.INoteTagRepository;

namespace Notes.Application.Commands.NoteTagCommands.Handlers
{
    public class RemoveTagFromNoteHandler
    {
        private readonly INoteTagRepository _noteTagRepository;

        public RemoveTagFromNoteHandler(INoteTagRepository noteTagRepository)
        {
            _noteTagRepository = noteTagRepository;
        }

        public async Task Handle(AddOrRemoveTagFromNoteCommand command)
        {
            await _noteTagRepository.RemoveTagToNoteAsync(command.TagId, command.NoteId);
        }
    }
}
