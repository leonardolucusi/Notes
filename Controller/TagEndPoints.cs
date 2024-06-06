using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Notes.Domain.Entities;
using Notes.Infra;

namespace Notes.Controller
{
    public static class TagEndPoints
    {
        public static void MapTagEndPoints(this WebApplication app)
        {
            app.MapGet("/tag", async (Context db) =>
            {
                var tags = await db.Tags.ToListAsync();
                if(tags == null) return Results.Ok("There is no Tags");
                return Results.Ok(tags);
            }).WithTags("Tags");

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
