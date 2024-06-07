using Microsoft.EntityFrameworkCore;
using Notes.Domain.Entities;
using Notes.Domain.Repositories;

namespace Notes.Infra.Data.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly Context _context;

        public TagRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tag>> GetTagsByIdsAsync(IEnumerable<int> tagIds)
        {
            return await _context.Tags.Where(tag => tagIds.Contains(tag.Id)).ToListAsync();
        }
    }
}
