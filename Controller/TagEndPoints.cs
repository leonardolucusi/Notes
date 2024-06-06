using Notes.Domain.Entities;
using Notes.Infra;

namespace Notes.Controller
{
    public static class TagEndPoints
    {
        public static void MapTagEndPoints(this WebApplication app)
        {
            app.MapPost("/tag", async (Tag tag, Context db) =>
            {
                if (tag == null || tag.Name == "") { return Results.BadRequest(); }
                db.Tags.Add(tag);
                await db.SaveChangesAsync();
                return Results.Ok();
            }).WithTags("Tags");
        }
    }
}
