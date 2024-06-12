using Notes.Application.Commands.NoteCommands.Handlers;
using Notes.Application.Commands.NoteTagCommands.Handlers;
using Notes.Application.Commands.TagCommands.Handlers;
using Notes.Application.Mapping;
using Notes.Application.Queries.NoteQueries.Handlers;
using Notes.Application.Queries.TagQueries.Handlers;
using Notes.Domain.Repositories.INoteRepository.CommandRepository;
using Notes.Domain.Repositories.INoteRepository.QueryRepository;
using Notes.Domain.Repositories.INoteTagRepository;
using Notes.Domain.Repositories.ITagRepository.CommandRepository;
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

            // NOTE
            services.AddScoped<INoteDeleteCommandRepository, NoteCommandRepository>();
            services.AddScoped<INoteUpdateTitleCommandRepository, NoteCommandRepository>();
            services.AddScoped<INoteUpdateContentCommandRepository, NoteCommandRepository>();
            services.AddScoped<INoteAddComandRepository, NoteCommandRepository>();
            services.AddScoped<INoteUpdateIsArchivedCommandRepository, NoteCommandRepository>();
            services.AddScoped<INoteUpdateIsFavoriteCommandRepository, NoteCommandRepository>();

            services.AddScoped<INoteGetTotalCountQueryRepository, NoteQueryRepository>();
            services.AddScoped<INoteGetAllQueryRepository, NoteQueryRepository>();
            services.AddScoped<INoteGetPaginatedQueryRepository, NoteQueryRepository>();

            // NOTETAG
            services.AddScoped<INoteTagRepository, NoteTagRepository>();

            // TAG
            services.AddScoped<ITagGetAllQueryRepository, TagQueryRepository>();
            services.AddScoped<ITagByIdQueryRepository, TagQueryRepository>();

            services.AddScoped<ITagAddCommandRepository, TagCommandRepository>();
            services.AddScoped<ITagRemoveCommandRepository, TagCommandRepository>();

            services.AddScoped<GetAllTagsHandler>();
            services.AddScoped<CreateTagHandler>();
            services.AddScoped<RemoveTagHandler>();

            services.AddScoped<RemoveTagFromNoteHandler>();
            services.AddScoped<AddTagToNoteHandler>();

            services.AddScoped<GetAllNotesHandler>();
            services.AddScoped<GetPaginationNotesHandler>();

            services.AddScoped<CreateNoteHandler>();
            services.AddScoped<UpdateNoteTitleHandler>();
            services.AddScoped<UpdateNoteContentHandler>();
            services.AddScoped<DeleteNoteHandler>();
            services.AddScoped<UpdateNoteIsArchivedHandler>();
            services.AddScoped<UpdateNoteIsFavoriteHandler>();
        }
    }
}
