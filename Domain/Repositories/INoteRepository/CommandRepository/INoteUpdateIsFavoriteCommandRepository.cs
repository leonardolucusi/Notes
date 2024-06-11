namespace Notes.Domain.Repositories.INoteRepository.CommandRepository
{
    public interface INoteUpdateIsFavoriteCommandRepository
    {
        Task UpdateIsFavoriteAsync(int noteId, bool isArchived);
    }
}
