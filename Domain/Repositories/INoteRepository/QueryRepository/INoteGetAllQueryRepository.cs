using Notes.Domain.Entities;

namespace Notes.Domain.Repositories.INoteRepository.QueryRepository
{
    public interface INoteGetAllQueryRepository
    {
        public Task<IEnumerable<Note>> GetAllNotesAsync();
    }
}
