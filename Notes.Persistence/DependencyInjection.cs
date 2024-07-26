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

            //services.AddScoped<IRepository<Note>>(provider => provider.GetService<Repository<Note>>());
            services.AddScoped<IRepository<Reminder>>(provider => provider.GetService<Repository<Reminder>>());
            services.AddScoped<IRepository<Tag>>(provider => provider.GetService<Repository<Tag>>());
            services.AddScoped<IRepository<Item>>(provider => provider.GetService<Repository<Item>>());
            services.AddScoped<IRepository<Entity>>(provider => provider.GetService<Repository<Entity>>());

            services.AddScoped<IRepository<Note>, Repository<Note>>();//todo: переделать строки выше по этому образу

            return services;
        }
    }
}
