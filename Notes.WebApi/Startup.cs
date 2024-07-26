using Notes.Application;
using Notes.Persistence;

namespace Notes.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddMediatR(cfg =>
            {
                cfg.RegisterGenericHandlers = true;
                cfg.MaxGenericTypeParameters = 2;
                cfg.RegisterServicesFromAssemblies(
                typeof(Application.Commands.Create.CreateNoteCommand).Assembly,
                typeof(Domain.Models.Entity).Assembly,
                typeof(Persistence.Repository<>).Assembly,
                typeof(WebApi.Program).Assembly);
            }
                );

        }
        public void Configure(IApplicationBuilder application, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
                application.UseSwagger();
                application.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }
            application.UseRouting();
            application.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
