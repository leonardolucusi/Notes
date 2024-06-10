using Notes.Application.Commands.NoteCommands.Handlers;
using Notes.Application.Commands.NoteTagCommands.Handlers;
using Notes.Application.Mapping;
using Notes.Application.Queries.NoteQueries.Handlers;
using Notes.Application.Queries.TagQueries.Handlers;
using Notes.Application.Queries.TagQueries.Models;
using Notes.Domain.Repositories;
using Notes.Domain.Repositories.ITagRepository.ITagQueryRepository;
using Notes.Domain.Repositories.ITagRepository.ITagQueryRepository.ITagQueryRepository;
using Notes.Infra.Data.Repositories;

namespace Notes.Infra.IoC
{
    public static class DI
    {
        public static void AddDependecyInjection(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(NoteProfile).Assembly);

            services.AddScoped<INoteCommandRepository, NoteCommandRepository>();
            services.AddScoped<INoteQueryRepository, NoteQueryRepository>();
            services.AddScoped<INoteTagRepository, NoteTagRepository>();
            services.AddScoped<ITagGetAllQueryRepository, TagQueryRepository>();
            services.AddScoped<ITagByIdQueryRepository, TagQueryRepository>();

            services.AddScoped<GetAllTagsHandler>();
            services.AddScoped<AddTagToNoteHandler>();
            services.AddScoped<RemoveTagFromNoteHandler>();
            services.AddScoped<GetAllNotesHandler>();
            services.AddScoped<GetPaginationNotesHandler>();
            services.AddScoped<CreateNoteHandler>();
            services.AddScoped<UpdateNoteTitleHandler>();
            services.AddScoped<UpdateNoteContentHandler>();
            services.AddScoped<DeleteNoteHandler>();
        }
    }
}
