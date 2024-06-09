using Microsoft.EntityFrameworkCore;
using Notes.Application.Commands.NoteCommands.Handlers;
using Notes.Application.Commands.NoteCommands.Models;
using Notes.Application.Queries.Handlers;
using Notes.Application.Queries.Models;
using Notes.Infra;
using Notes.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependecyInjection();

builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Context")
    ?? throw new InvalidOperationException("Connection string 'Context' not found.")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// QUERIES

app.MapGet("/v1/api/notes/", async (GetAllNotesHandler getAllNotesHandler) =>
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
});

app.MapGet("/v1/api/notes/{x}/{y}", async (int x, int y, GetPaginationNotesHandler getPaginationNotesHandler) =>
{
    try
    {
        var query = new GetPaginationNotesQuery { PageNumber = x, PageSize = y };
        var result = await getPaginationNotesHandler.Handle(query);
        return Results.Ok(result);
    }
    catch (Exception ex)
    {
        // Trate exceções conforme necessário
        return Results.BadRequest(new { message = $"Error getting paginated notes: {ex.Message}" });
    }
});

// COMMANDS

app.MapPost("/v1/api/notes/", async (CreateNoteCommand command, CreateNoteHandler createNoteHandler) =>
{
    try
    {
        await createNoteHandler.Handle(command);
        return Results.Ok("Nota created successfully.");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { message = $"Error creating note: {ex.Message}" });
    }
});

app.MapDelete("/v1/api/notes/{id}", async (int id, DeleteNoteHandler deleteNoteHandler) =>
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
});

app.MapPatch("/v1/api/notes/{id}/title", async (UpdateNoteTitleCommand updateNoteTitleCommand, UpdateNoteTitleHandler updateNoteHandler) =>
{
    try
    {
        if (string.IsNullOrEmpty(updateNoteTitleCommand.Title))
        {
            return Results.BadRequest(new { message = "Title can't be empty." });
        }

        await updateNoteHandler.Handle(updateNoteTitleCommand);
        return Results.Ok("Note title update was successful");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { message = $"Error updating note: {ex.Message}" });
    }
});

app.MapPatch("/v1/api/notes/{id}/content", async (UpdateNoteContentCommand updateNoteContentCommand, UpdateNoteContentHandler updateNoteContentHandler) =>
{
    try
    {
        await updateNoteContentHandler.Handle(updateNoteContentCommand);
        return Results.Ok("Note content update was successful");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { message = $"Error updating note: {ex.Message}" });
    }
});

app.Run();
