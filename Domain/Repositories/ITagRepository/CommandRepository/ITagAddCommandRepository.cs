using Notes.Domain.Entities;

namespace Notes.Domain.Repositories.ITagRepository.CommandRepository
{
    public interface ITagAddCommandRepository
    {
        Task AddTagAsync(Tag tag); 
    }
}
