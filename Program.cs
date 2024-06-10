using Microsoft.EntityFrameworkCore;
using Notes.Infra;
using Notes.Infra.IoC;
using Notes.Presentation.Endpoints.Commands;
using Notes.Presentation.Endpoints.Queries;

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

app.MapNoteCommandsEndpoints();
app.MapNoteTagsCommandsEndPoints();

app.Run();
