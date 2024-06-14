using Microsoft.EntityFrameworkCore;
using Notes.Domain.Entities;
using Notes.Domain.Repositories.INoteRepository.QueryRepository;
using Notes.Infra.Data.Context;

namespace Notes.Infra.Data.Repositories
{
    public class NoteQueryRepository : INoteGetTotalCountQueryRepository, INoteGetAllQueryRepository, INoteGetPaginatedQueryRepository
    {
        private readonly NoteDbContext _context;
        public NoteQueryRepository(NoteDbContext context)
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
            return await _context.Notes
                .OrderByDescending(n => n.CreatedDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalCount()
        {
            return await _context.Notes.CountAsync();
        }
    }
}

