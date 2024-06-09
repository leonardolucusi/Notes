using Notes.Domain.Entities;

namespace Notes.Domain.Repositories
{
    public interface INoteCommandRepository
    {
        Task AddNoteAsync(Note note);
        Task UpdateNoteTitleAsync(int id, string newTitle);
        Task UpdateNoteContentAsync(int id, string newContent);
        Task DeleteNoteAsync(int id);
    }
}
