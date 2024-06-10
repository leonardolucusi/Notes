using Notes.Application.Commands.NoteTagCommands.Models;
using Notes.Domain.Repositories;

namespace Notes.Application.Commands.NoteTagCommands.Handlers
{
    public class AddTagToNoteHandler
    {
        private readonly INoteTagRepository _noteTagRepository;

        public AddTagToNoteHandler(INoteTagRepository noteTagRepository)
        {
            _noteTagRepository = noteTagRepository;
        }
        public async Task Handle(AddOrRemoveTagFromNoteCommand command)
        {
            await _noteTagRepository.AddTagToNoteAsync(command.TagId, command.NoteId);
        }
    }
}
