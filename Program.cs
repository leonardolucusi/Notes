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
//app.MapNoteEndPoints();
//app.MapTagEndPoints();
//app.MapNoteTagEndPoints();

app.MapPost("/v1/api/notes/", async (CreateNoteCommand command, CreateNoteHandler createNoteHandler) =>
{
    try
    {
        await createNoteHandler.Handle(command);
        return Results.Ok("Nota criada com sucesso.");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { message = $"Erro ao criar nota: {ex.Message}" });
    }
});

app.MapDelete("/v1/api/notes/{id}", async (int id, DeleteNoteHandler deleteNoteHandler) =>
{
    try
    {
        var deleteNoteCommand = new DeleteNoteCommand { Id = id };
        await deleteNoteHandler.Handle(deleteNoteCommand);
        return Results.Ok("Nota deletada com sucesso.");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { message = $"Erro ao deletar nota: {ex.Message}" });
    }
});

app.MapPatch("/v1/api/notes/{id}", async (UpdateNoteTitleCommand updateNoteTitleCommand, UpdateNoteTitleHandler updateNoteHandler) =>
{
    try
    {
        if (string.IsNullOrEmpty(updateNoteTitleCommand.Title))
        {
            return Results.BadRequest(new { message = "O título da nota não pode estar vazio." });
        }

        await updateNoteHandler.Handle(updateNoteTitleCommand);
        return Results.Ok("Note update successfully");
    }
    catch(Exception ex)
    {
        return Results.BadRequest(new {message = $"Erro ao alterar nota: {ex.Message}" });
    }
});

app.Run();
