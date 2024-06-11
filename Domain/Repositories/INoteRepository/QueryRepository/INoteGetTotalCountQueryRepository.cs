namespace Notes.Domain.Repositories.INoteRepository.QueryRepository
{
    public interface INoteGetTotalCountQueryRepository
    {
        public Task<int> GetTotalCount();
    }
}
