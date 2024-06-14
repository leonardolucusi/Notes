using Microsoft.EntityFrameworkCore;
using Notes.Domain.Entities;
using Notes.Domain.Repositories.ITagRepository.ITagQueryRepository;
using Notes.Domain.Repositories.ITagRepository.ITagQueryRepository.ITagQueryRepository;
using Notes.Infra.Data.Context;

namespace Notes.Infra.Data.Repositories
{
    public class TagQueryRepository : ITagGetAllQueryRepository, ITagByIdQueryRepository
    {
        private readonly NoteDbContext _context;

        public TagQueryRepository(NoteDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag> GetTagByIdAsync(int id)
        {
            return await _context.Tags.FindAsync(id);
        }

        public async Task<IEnumerable<Tag>> GetTagsByIdsAsync(IEnumerable<int> tagIds)
        {
            return await _context.Tags.Where(tag => tagIds.Contains(tag.Id)).ToListAsync();
        }
    }
}
