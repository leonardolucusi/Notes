using Microsoft.EntityFrameworkCore;
using Notes.Infra;
using Notes.Application.Commands.Handlers;
using Notes.Application.Commands.Models;
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

app.MapPatch("/v1/api/notes/{id}", async (UpdateNoteTitleCommand updateNoteTitleCommand, UpdateNoteTitleHandler updateNoteHandler) =>
{
    try
    {
        if (string.IsNullOrEmpty(updateNoteTitleCommand.Title))
        {
            return Results.BadRequest(new { message = "Title can't be empty." });
        }

        await updateNoteHandler.Handle(updateNoteTitleCommand);
        return Results.Ok("Note update successfully");
    }
    catch(Exception ex)
    {
        return Results.BadRequest(new {message = $"Error updating note: {ex.Message}" });
    }
});

app.Run();
