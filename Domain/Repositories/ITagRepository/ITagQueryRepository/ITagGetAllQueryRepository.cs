using Notes.Domain.Entities;

namespace Notes.Domain.Repositories.ITagRepository.ITagQueryRepository
{
    public interface ITagGetAllQueryRepository
    {
        Task<IEnumerable<Tag>> GetAllTagsAsync();
    }
}
