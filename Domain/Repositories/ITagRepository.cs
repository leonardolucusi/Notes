using Notes.Domain.Entities;

namespace Notes.Domain.Repositories
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetTagsByIdsAsync(IEnumerable<int> tagIds);
    }
}
