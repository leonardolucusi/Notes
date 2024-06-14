using Notes.Domain.Entities;

namespace Notes.Domain.Repositories.INoteRepository.QueryRepository
{
    public interface INoteGetNotesByTagQueryRepository
    {
        Task<IEnumerable<Note>> GetNotesByTag(int tagId);
    }
}
