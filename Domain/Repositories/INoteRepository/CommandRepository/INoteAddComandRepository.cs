using Notes.Domain.Entities;

namespace Notes.Domain.Repositories.INoteRepository.CommandRepository
{
    public interface INoteAddComandRepository
    {
        Task AddNoteAsync(Note note);
    }
}
