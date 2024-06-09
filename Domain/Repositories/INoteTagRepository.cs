
namespace Notes.Domain.Repositories
{
    public interface INoteTagRepository
    {
        Task AddTagToNoteAsync(int tagId, int noteId);
        Task RemoveTagToNoteAsync(int tagId, int noteId);
    }
}
