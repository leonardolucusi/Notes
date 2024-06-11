using Notes.Application.Commands.NoteCommands.Handlers;
using Notes.Application.Commands.NoteCommands.Models;

namespace Notes.Presentation.Endpoints.Commands
{
    public static class NoteCommandsEndPoints
    {
        public static void MapNoteCommandsEndpoints(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapPost("/v1/api/notes/", async (CreateNoteCommand command, CreateNoteHandler createNoteHandler) =>
            {
                try
                {
                    await createNoteHandler.Handle(command);
                    return Results.Ok("Note created successfully.");
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"Error creating note: {ex.Message}" });
                }
            }).WithTags("Notes");

            endpoint.MapDelete("/v1/api/notes/{id}", async (int id, DeleteNoteHandler deleteNoteHandler) =>
            {
                try
                {
                    var deleteNoteCommand = new DeleteNoteCommand { Id = id };
                    await deleteNoteHandler.Handle(deleteNoteCommand);
                    return Results.Ok("Note deleted successfully.");
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"Error deleting note: {ex.Message}" });
                }
            }).WithTags("Notes");

            endpoint.MapPatch("/v1/api/notes/{id}/title", async (UpdateNoteTitleCommand updateNoteTitleCommand, UpdateNoteTitleHandler updateNoteHandler) =>
            {
                try
                {
                    if (string.IsNullOrEmpty(updateNoteTitleCommand.Title))
                    {
                        return Results.BadRequest(new { message = "Title can't be empty." });
                    }

                    await updateNoteHandler.Handle(updateNoteTitleCommand);
                    return Results.Ok("Note title updated successfully.");
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"Error updating note: {ex.Message}" });
                }
            }).WithTags("Notes");

            endpoint.MapPatch("/v1/api/notes/{id}/content", async (UpdateNoteContentCommand updateNoteContentCommand, UpdateNoteContentHandler updateNoteContentHandler) =>
            {
                try
                {
                    await updateNoteContentHandler.Handle(updateNoteContentCommand);
                    return Results.Ok("Note content updated successfully.");
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"Error updating note: {ex.Message}" });
                }
            }).WithTags("Notes");

            endpoint.MapPatch("/v1/api/notes/{id}/isarchived", async (UpdateNoteIsArchivedCommand updateNoteIsArchivedCommand, UpdateNoteIsArchivedHandler updateNoteIsArchivedHandler) =>
            {
                try
                {
                    await updateNoteIsArchivedHandler.Handle(updateNoteIsArchivedCommand);
                    return Results.Ok("Note content updated successfully.");
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"Error updating note: {ex.Message}" });
                }
            }).WithTags("Notes");
        }
    }
}
