using Notes.Application.Queries.NoteQueries.Handlers;
using Notes.Application.Queries.NoteQueries.Models;

namespace Notes.Presentation.Endpoints.NotesEndpoints.Queries
{
    public static class NoteQueriesEndPoints
    {
        public static void MapNoteQueriesEndpoints(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapGet("/v1/api/notes/", async (GetAllNotesHandler getAllNotesHandler) =>
            {
                try
                {
                    var notes = await getAllNotesHandler.Handle(new GetAllNotesQuery());
                    return Results.Ok(notes);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"Error getting notes: {ex.Message}" });
                }
            }).WithTags("Notes");

            endpoint.MapGet("/v1/api/notes/{pageNumber}/{pageSize}", async (int pageNumber, int pageSize, GetPaginationNotesHandler getPaginationNotesHandler) =>
            {
                try
                {
                    var query = new GetPaginationNotesQuery { PageNumber = pageNumber, PageSize = pageSize };
                    var result = await getPaginationNotesHandler.Handle(query);
                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"Error getting paginated notes: {ex.Message}" });
                }
            }).WithTags("Notes");
        }
    }
}
