﻿using Notes.Domain.Entities;
using Notes.Domain.Repositories.ITagRepository.CommandRepository;

namespace Notes.Infra.Data.Repositories
{
    public class TagCommandRepository :
        ITagAddCommandRepository,
        ITagRemoveCommandRepository
    {
        private readonly Context _context;
        public TagCommandRepository(Context context)
        {
            _context = context;
        }

        public async Task AddTagAsync(Tag tag)
        {
            _context.Tags.Add(tag);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveTagAsync(int? id)
        {
            var tag = await _context.Tags.FindAsync(id);
            if (tag != null)
            {
                _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
                return;
            }
            throw new InvalidOperationException("Tag not found.");
        }
    }
}
