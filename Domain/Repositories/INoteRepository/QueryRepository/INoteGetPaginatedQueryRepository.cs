using Notes.Domain.Entities;

namespace Notes.Domain.Repositories.INoteRepository.QueryRepository
{
    public interface INoteGetPaginatedQueryRepository
    {
        Task<IEnumerable<Note>> GetPaginatedNotes(int pageNumber, int pageSize);
    }
}
