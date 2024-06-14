using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Commands.NoteCommands.Validators;
using Notes.Infra.IoC;
using Notes.Presentation.Endpoints.NotesEndpoints.Commands;
using Notes.Presentation.Endpoints.NotesEndpoints.Queries;
using Notes.Presentation.Endpoints.NoteTagEndpoints.Commands;
using Notes.Presentation.Endpoints.TagEndpoints.Commands;
using Notes.Presentation.Endpoints.TagEndpoints.Queries;
using Notes.Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDependecyInjection();

builder.Services.AddDbContext<NoteDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Context")
    ?? throw new InvalidOperationException("Connection string 'Context' not found.")));

builder.Services.AddValidatorsFromAssemblyContaining<CreateNoteCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateTitleNoteCommandValidator>();
builder.Services.AddFluentValidationAutoValidation();

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
