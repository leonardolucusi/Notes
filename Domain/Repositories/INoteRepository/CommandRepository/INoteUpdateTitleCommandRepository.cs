namespace Notes.Domain.Repositories.INoteRepository.CommandRepository
{
    public interface INoteUpdateTitleCommandRepository
    {
        Task UpdateNoteTitleAsync(int id, string newTitle);
    }
}
