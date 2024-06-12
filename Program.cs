using Microsoft.EntityFrameworkCore;
using Notes.Infra;
using Notes.Infra.IoC;
using Notes.Presentation.Endpoints.NotesEndpoints.Commands;
using Notes.Presentation.Endpoints.NotesEndpoints.Queries;
using Notes.Presentation.Endpoints.NoteTagEndpoints.Commands;
using Notes.Presentation.Endpoints.TagEndpoints.Commands;
using Notes.Presentation.Endpoints.TagEndpoints.Queries;

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

app.MapNoteQueriesEndpoints();

app.MapTagCommandsEndPoints();
app.MapTagQueriesEndpoints();

app.MapNoteCommandsEndpoints();
app.MapNoteTagsCommandsEndPoints();

app.Run();
