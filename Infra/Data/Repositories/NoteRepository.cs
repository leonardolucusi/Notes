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

        public async Task DeleteNoteAsync(int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note != null)
            {
                 _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
                return;
            }
            throw new InvalidOperationException("Note not found.");
        }
    }
}
