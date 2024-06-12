using Notes.Application.Commands.TagCommands.Handlers;
using Notes.Application.Commands.TagCommands.Models;

namespace Notes.Presentation.Endpoints.TagEndpoints.Commands
{
    public static class TagCommandsEndPoints
    {
        public static void MapTagCommandsEndPoints(this IEndpointRouteBuilder endpoint)
        {
            endpoint.MapPost("/v1/api/tag/", async (CreateTagCommand command, CreateTagHandler createTagHandler) =>
            {
                try
                {
                    await createTagHandler.Handle(command);
                    return Results.Ok("Tag created successfully");
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"Error creating tag: {ex.Message}" });
                }
            }).WithTags("Tags");

            endpoint.MapDelete("/v1/api/tag/{id}", async (int id, RemoveTagHandler removeTagHandler) =>
            {
                try
                {
                    var addOrDeleteNoteCommand = new RemoveTagCommand { Id = id };
                    await removeTagHandler.Handle(addOrDeleteNoteCommand);
                    return Results.Ok("Tag remove successfully");
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(new { message = $"Error creating tag: {ex.Message}" });
                }
            }).WithTags("Tags"); ;
        }
    }
}
