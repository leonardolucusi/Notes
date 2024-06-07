using Notes.Domain.Entities;
using Notes.Domain.Repositories;

namespace Notes.Infra.Data.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly Context _context;

        public NoteRepository(Context context)
        {
            _context = context;
        }

        public async Task AddNoteAsync(Note note)
        {
            _context.Add(note);
            await _context.SaveChangesAsync();
        }
    }
}
