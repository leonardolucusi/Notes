using Notes.Domain.Entities;

namespace Notes.Domain.Repositories.ITagRepository.ITagQueryRepository.ITagQueryRepository
{
    public interface ITagByIdQueryRepository
    {
        Task<Tag> GetTagByIdAsync(int id);
        Task<IEnumerable<Tag>> GetTagsByIdsAsync(IEnumerable<int> tagIds);
    }
}
