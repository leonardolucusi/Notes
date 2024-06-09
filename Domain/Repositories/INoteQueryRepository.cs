using Notes.Domain.Entities;

namespace Notes.Domain.Repositories
{
    public interface INoteQueryRepository
    {
        public Task<IEnumerable<Note>> GetAllNotesAsync();
    }
}
