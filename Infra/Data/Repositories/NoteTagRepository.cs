﻿using Notes.Domain.Entities;
using Notes.Domain.Repositories.INoteTagRepository;
using Notes.Infra.Data.Context;

namespace Notes.Infra.Data.Repositories
{
    public class NoteTagRepository : INoteTagRepository
    {
        private readonly NoteDbContext _context;

        public NoteTagRepository(NoteDbContext context)
        {
            _context = context;
        }

        public async Task AddTagToNoteAsync(int tagId, int noteId)
        {
            var noteTag = new NoteTag { TagId = tagId, NoteId = noteId };
            _context.NoteTags.Add(noteTag);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveTagToNoteAsync(int tagId, int noteId)
        {
            var noteTag = new NoteTag { TagId = tagId, NoteId = noteId };
            _context.NoteTags.Remove(noteTag);
            await _context.SaveChangesAsync();
        }
    }
}
