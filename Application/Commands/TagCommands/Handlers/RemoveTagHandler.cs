using Notes.Application.Commands.TagCommands.Models;
using Notes.Domain.Repositories.ITagRepository.CommandRepository;

namespace Notes.Application.Commands.TagCommands.Handlers
{
    public class RemoveTagHandler
    {
        private readonly ITagRemoveCommandRepository _tagRemoveCommandRepository;
        public RemoveTagHandler(ITagRemoveCommandRepository tagRemoveCommandRepository)
        {
            _tagRemoveCommandRepository = tagRemoveCommandRepository;
        }

        public async Task Handle(RemoveTagCommand command)
        {
            if(command.Id > 0)
            {
                await _tagRemoveCommandRepository.RemoveTagAsync(command.Id);
            }
        }
    }
}
