using Microsoft.EntityFrameworkCore;
using Notes.Domain.DTO;
using Notes.Domain.Entities;
using Notes.Infra;

namespace Notes.Controller
{
    public static class NoteEndPoints
    {
        public static void MapNoteEndPoints(this WebApplication app)
        {
            app.MapGet("/v1/notes", async (Context db) =>
            {
                var notes = await db.Notes
                    .Include(n => n.NoteTags)
                    .ThenInclude(nt => nt.Tag)
                    .ToListAsync();

                if (notes == null)
                {
                    return Results.NotFound();
                }

                var noteDTOs = notes.Select(n => new NoteDTO
                {
                    Id = n.Id,
                    Title = n.Title,
                    Tags = n.NoteTags.Select(nt => new TagDTO
                    {
                        Id = nt.Tag.Id,
                        Name = nt.Tag.Name
                    }).ToList()
                }).ToList();

                return Results.Ok(noteDTOs);
            }).WithTags("Notes");

            // get the amount needed only
            app.MapGet("/v1/note/{num}", async (int num, Context db) =>
            {
                if (num <= 0) return Results.BadRequest("The number of notes to retrieve must be greater than zero.");
                var notes = await db.Notes
                .Include(n => n.NoteTags)
                .ThenInclude(nt => nt.Tag)
                .Take(num)
                .ToListAsync();

                if (notes == null || notes.Count == 0)
                {
                    return Results.NotFound();
                }

                var noteDTOs = notes.Select(n => new NoteDTO
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    Tags = n.NoteTags.Select(nt => new TagDTO
                    {
                        Id = nt.Tag.Id,
                        Name = nt.Tag.Name
                    }).ToList()
                }).ToList();

                return Results.Ok(noteDTOs);
            }).WithTags("Notes");

            app.MapGet("/v1/notes/{id}", async (int id, Context db) =>
            {
                var note = await db.Notes
                    .Include(n => n.NoteTags)
                    .ThenInclude(nt => nt.Tag)
                    .FirstOrDefaultAsync(n => n.Id == id);

                if (note == null)
                {
                    return Results.NotFound();
                }

                var noteDTO = new NoteDTO
                {
                    Id = note.Id,
                    Title = note.Title,
                    Content = note.Content,
                    Tags = note.NoteTags.Select(nt => new TagDTO
                    {
                        Id = nt.Tag.Id,
                        Name = nt.Tag.Name
                    }).ToList()
                };

                return Results.Ok(noteDTO);
            });

            app.MapPost("/v1/note", async (Note note, Context db) =>
            {
                db.Notes.Add(note);
                await db.SaveChangesAsync();
                return Results.Ok();
            });

            app.MapPatch("/v1/notetitle/{id}", async (int id, string newTitle, Context db) =>
            {
                var note = await db.Notes.FirstOrDefaultAsync(n => n.Id == id);

                if (note == null)
                {
                    return Results.NotFound();
                }

                note.Title = newTitle;
                note.UpdateLastModified();

                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            app.MapPatch("/v1/notecontent/{id}", async (int id, string newContent, Context db) =>
            {
                var note = await db.Notes.FirstOrDefaultAsync(n => n.Id == id);

                if (note == null) { return Results.NotFound(); }

                note.Content = newContent;
                note.UpdateLastModified();
                await db.SaveChangesAsync();

                return Results.NoContent();
            });

            app.MapDelete("/v1/notedelete/{id}", async (int id, Context db) =>
            {
                var note = await db.Notes.FirstOrDefaultAsync(n => n.Id == id);

                if (note == null) { return Results.NotFound(); }

                db.Notes.Remove(note);
                await db.SaveChangesAsync();

                return Results.NoContent();
            });
        }
    }
}
