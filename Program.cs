using Microsoft.EntityFrameworkCore;
using Notes.Infra;
using Notes.Domain.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Notes.Domain.Entities;

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

    if(notes == null)
    {
        return Results.NotFound();
    }

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

app.MapGet("/notesitems/{id}", async (int id, Context db) =>
{
    var note = await db.Notes
        .Include(n => n.NoteTags)
        .ThenInclude(nt => nt.Tag)
        .FirstOrDefaultAsync(n => n.Id == id);

    if (note == null)
    {
        return Results.NotFound();
    }

    var noteDTO = new NoteDTO
    {
        Id = note.Id,
        Title = note.Title,
        Content = note.Content,
        Tags = note.NoteTags.Select(nt => new TagDTO
        {
            Id = nt.Tag.Id,
            Name = nt.Tag.Name
        }).ToList()
    };

    return Results.Ok(noteDTO);
});

app.MapPost("/noteitem", async (Note note, Context db) =>
{
    db.Notes.Add(note);
    await db.SaveChangesAsync();
    return Results.Ok();
});



app.Run();
