using Notes.Domain.Entities;

namespace Notes.Domain.Repositories
{
    public interface INoteRepository
    {
        Task AddNoteAsync(Note note);
        Task DeleteNoteAsync(int id);
    }
}
