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

        public async Task UpdateNoteContentAsync(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateNoteTitleAsync(int id, string newTitle)
        {
            var existingNote = await _context.Notes.FindAsync(id);
            if(existingNote != null)
            {
                existingNote.Title = newTitle;
                existingNote.UpdateLastModified();
                _context.Notes.Update(existingNote);
                await _context.SaveChangesAsync();
                return;
            }
            throw new InvalidOperationException("Note not found.");
        }
    }
}
