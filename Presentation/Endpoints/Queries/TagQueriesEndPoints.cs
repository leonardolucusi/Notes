using Notes.Application.Queries.TagQueries.Handlers;
using Notes.Application.Queries.TagQueries.Models;

namespace Notes.Presentation.Endpoints.Queries
{
    public static class TagQueriesEndPoints
    {
        public static void MapTagQueriesEndpoints(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapGet("/v1/api/tags/", async (GetAllTagsHandler getAllTagsHandler) =>
            {
                try
                {
                    var tags = await getAllTagsHandler.Handle(new GetAllTagsQuery());
                    return Results.Ok(tags);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"Error getting tags: {ex.Message}" });
                }
            }).WithTags("Tags");
        }
    }
}
