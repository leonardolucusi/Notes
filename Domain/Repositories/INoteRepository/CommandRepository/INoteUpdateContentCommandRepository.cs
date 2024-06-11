namespace Notes.Domain.Repositories.INoteRepository.CommandRepository
{
    public interface INoteUpdateContentCommandRepository
    {
        Task UpdateNoteContentAsync(int id, string newContent);
    }
}
