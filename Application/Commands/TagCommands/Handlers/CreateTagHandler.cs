using Microsoft.IdentityModel.Tokens;
using Notes.Application.Commands.TagCommands.Models;
using Notes.Domain.Entities;
using Notes.Domain.Repositories.ITagRepository.CommandRepository;

namespace Notes.Application.Commands.TagCommands.Handlers
{
    public class CreateTagHandler
    {
        private readonly ITagAddCommandRepository _tagAddCommandRepository;
        public CreateTagHandler(ITagAddCommandRepository tagAddCommandRepository)
        {
            _tagAddCommandRepository = tagAddCommandRepository;
        }

        public async Task Handle(CreateTagCommand command)
        {
            if (String.IsNullOrEmpty(command.Name))
                throw new ArgumentNullException(nameof(command));

            var tag = new Tag
            {
                Name = command.Name
            };

            await _tagAddCommandRepository.AddTagAsync(tag);
        }

    }
}
