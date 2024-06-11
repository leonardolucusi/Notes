namespace Notes.Domain.Repositories.INoteTagRepository
{
    public interface INoteTagRepository
    {
        Task AddTagToNoteAsync(int tagId, int noteId);
        Task RemoveTagToNoteAsync(int tagId, int noteId);
    }
}
