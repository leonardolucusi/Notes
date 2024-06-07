using Microsoft.EntityFrameworkCore;
using Notes.Infra;
using Notes.Controller;

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

app.MapNoteEndPoints();
app.MapTagEndPoints();
app.MapNoteTagEndPoints();

app.Run();

/*adicionar repositories, 
 * cqrs,
 * deletar controller,
 * segregar responsabilidades, */