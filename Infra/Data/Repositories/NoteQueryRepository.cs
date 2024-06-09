using Microsoft.EntityFrameworkCore;
using Notes.Domain.Entities;
using Notes.Domain.Repositories;

namespace Notes.Infra.Data.Repositories
{
    public class NoteQueryRepository : INoteQueryRepository
    {
        private readonly Context _context;
        public NoteQueryRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Note>> GetAllNotesAsync()
        {
            return await _context.Notes
          .Include(n => n.NoteTags)
          .ThenInclude(nt => nt.Tag)
          .ToListAsync();
        }

        public async Task<IEnumerable<Note>> GetPaginatedNotes(int pageNumber, int pageSize)
        {
            int skip = (pageNumber - 1) * pageSize;

            return await _context.Notes
                .OrderByDescending(n => n.CreatedDate)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalCount()
        {
            return await _context.Notes.CountAsync();
        }
    }
}

