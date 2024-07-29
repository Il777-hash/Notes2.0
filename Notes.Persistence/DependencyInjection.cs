using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notes.Application.Interfaces;
using Notes.Domain.Models;

namespace Notes.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectingString = configuration["ConnectionStrings:SQLiteNotesContext"];
            services.AddDbContext<NotesDbContext>(optins =>
            {
                optins.UseSqlite(connectingString);
            });
            services.AddScoped<INotesDbContext>(provider => provider.GetService<NotesDbContext>());

            services.AddScoped<IRepository<Reminder>, Repository<Reminder>>();
            services.AddScoped<IRepository<Tag>, TagRepository>();
            services.AddScoped<IRepository<Note>, Repository<Note>>();

            return services;
        }
    }
}
