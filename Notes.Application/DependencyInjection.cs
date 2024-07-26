using Microsoft.Extensions.DependencyInjection;

namespace Notes.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterGenericHandlers = true;
                cfg.MaxGenericTypeParameters = 2;
                cfg.RegisterServicesFromAssemblies(
                    typeof(Application.Commands.Create.CreateNoteCommand).Assembly,
                    typeof(Domain.Models.Entity).Assembly
                );
            });
            return services;
        }
    }
}
