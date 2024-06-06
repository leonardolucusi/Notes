using Notes.Domain.Entities;
using Notes.Infra;

namespace Notes.Controller
{
    public static class NoteTagEndPoints
    {
        public static void MapNoteTagEndPoints(this WebApplication app)
        {
            app.MapPost("/v1/notetag", async (int noteId, int tagId, Context db) =>
            {
                if (noteId == null || tagId == null) { return Results.BadRequest(); }
                var noteTag = new NoteTag
                {
                    NoteId = noteId,
                    TagId = tagId
                };
                db.NoteTags.Add(noteTag);
                await db.SaveChangesAsync();
                return Results.Ok();
            }).WithTags("NoteTags");
        }
    }
}
