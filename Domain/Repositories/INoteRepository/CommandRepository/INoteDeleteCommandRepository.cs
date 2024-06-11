namespace Notes.Domain.Repositories.INoteRepository.CommandRepository
{
    public interface INoteDeleteCommandRepository
    {
        Task DeleteNoteAsync(int id);
    }
}
