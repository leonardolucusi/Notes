using Notes.Application.Commands.NoteTagCommands.Handlers;
using Notes.Application.Commands.NoteTagCommands.Models;

namespace Notes.Presentation.Endpoints.NoteTagEndpoints.Commands
{
    public static class NoteTagsCommandsEndPoints
    {
        public static void MapNoteTagsCommandsEndPoints(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapPost("/v1/api/notetag/{tagId}/{noteId}", async (int tagId, int noteId, AddTagToNoteHandler addTagToNoteHandler) =>
            {
                try
                {
                    var command = new AddOrRemoveTagFromNoteCommand { TagId = tagId, NoteId = noteId };
                    await addTagToNoteHandler.Handle(command);
                    return Results.Ok("Tag added to note successfully.");
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"Error adding tag to note: {ex.Message}" });
                }
            }).WithTags("NoteTags");

            endpoint.MapDelete("/v1/api/notetag/{tagId}/{noteId}", async (int tagId, int noteId, RemoveTagFromNoteHandler removeTagFromNoteHandler) =>
            {
                try
                {
                    var command = new AddOrRemoveTagFromNoteCommand { TagId = tagId, NoteId = noteId };
                    await removeTagFromNoteHandler.Handle(command);
                    return Results.Ok("Tag removed from note successfully.");
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"Error removing tag from note: {ex.Message}" });
                }
            }).WithTags("NoteTags");
        }
    }
}
