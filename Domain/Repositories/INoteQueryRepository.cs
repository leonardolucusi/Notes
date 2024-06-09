using Notes.Domain.Entities;

namespace Notes.Domain.Repositories
{
    public interface INoteQueryRepository
    {
        public Task<IEnumerable<Note>> GetAllNotesAsync();
        public Task<int> GetTotalCount();
        Task<IEnumerable<Note>> GetPaginatedNotes(int pageNumber, int pageSize);
    }
}
