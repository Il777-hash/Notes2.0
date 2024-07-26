using Microsoft.Extensions.DependencyInjection;

namespace Notes.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddMediatR(cfg =>
            //{
            //    cfg.RegisterServicesFromAssemblyContaining(typeof(IRequestHandler<>));
            //});
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly<CreateNoteCommandHandler>());
            //foreach (var assembly in AppDomain.CurrentDomain. GetAssemblies())
            //{

            //}

            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly, typeof(Entity).Assembly));

            return services;
        }
    }
}
