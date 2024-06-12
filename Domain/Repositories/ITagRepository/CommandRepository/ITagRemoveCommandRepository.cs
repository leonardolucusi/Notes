namespace Notes.Domain.Repositories.ITagRepository.CommandRepository
{
    public interface ITagRemoveCommandRepository
    {
        Task RemoveTagAsync(int? id);
    }
}
