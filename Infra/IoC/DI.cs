using Notes.Application.Commands.NoteCommands.Handlers;
using Notes.Application.Queries.Handlers;
using Notes.Domain.Repositories;
using Notes.Infra.Data.Repositories;

namespace Notes.Infra.IoC
{
    public static class DI
    {
        public static void AddDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<INoteCommandRepository, NoteCommandRepository>();
            services.AddScoped<INoteQueryRepository, NoteQueryRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<GetAllNotesHandler>();
            services.AddScoped<GetPaginationNotesHandler>();
            services.AddScoped<CreateNoteHandler>();
            services.AddScoped<UpdateNoteTitleHandler>();
            services.AddScoped<UpdateNoteContentHandler>();
            services.AddScoped<DeleteNoteHandler>();
        }
    }
}
