using Notes.Application.Commands.Services;
using Notes.Domain.Repositories;
using Notes.Infra.Data.Repositories;

namespace Notes.Infra.IoC
{
    public static class DI
    {
        public static void AddDependecyInjection(this IServiceCollection services)
        {
            services.AddScoped<INoteRepository,NoteRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
        }
    }
}
