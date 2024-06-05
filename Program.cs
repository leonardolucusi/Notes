using Microsoft.EntityFrameworkCore;
using Notes.Infra;
using System.Text.Json.Serialization;
using System.Text.Json;
using Notes.Domain.DTO;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapGet("/notesitems", async (Context db) =>
{
    var notes = await db.Notes
        .Include(n => n.NoteTags)
        .ThenInclude(nt => nt.Tag)
        .ToListAsync();

    // Converte as notas para DTOs
    var noteDTOs = notes.Select(n => new NoteDTO
    {
        Id = n.Id,
        Title = n.Title,
        Tags = n.NoteTags.Select(nt => new TagDTO
        {
            Id = nt.Tag.Id,
            Name = nt.Tag.Name
        }).ToList()
    }).ToList();

    return Results.Ok(noteDTOs);
});

app.Run();
