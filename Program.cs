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

app.MapPost("/api/notes", async (CreateNoteCommand command, CreateNoteHandler createNoteHandler) =>
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

app.MapDelete("/api/notes/{id}", async (int id, DeleteNoteHandler deleteNoteHandler) =>
{
    var command = new DeleteNoteCommand { Id = id };
    try
    {
        await deleteNoteHandler.Handle(command);
        return Results.Ok("Nota deletada com sucesso.");
    }
    catch (Exception ex)
    {
        return Results.BadRequest(new { message = $"Erro ao deletar nota: {ex.Message}" });
    }
});

app.Run();
