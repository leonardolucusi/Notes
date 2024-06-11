namespace Notes.Domain.Repositories.INoteRepository.CommandRepository
{
    public interface INoteUpdateIsArchivedCommandRepository
    {
        Task UpdateIsArchivedAsync(int noteId, bool isArchived);
    }
}
