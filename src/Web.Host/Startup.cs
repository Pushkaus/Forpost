using Forpost.Store.Postgres;

namespace Forpost.Web.Host;

internal sealed class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public static void ConfigureServices(IServiceCollection services)
    {

        services.AddControllers();
        services.AddPostgresDbContext();
        services.AddAuthorization();
        services.AddSwaggerGen();
    }


    public static void Configure(IApplicationBuilder app, IHostEnvironment environment)
    {
        app.UseRouting();
        
        app.UseEndpoints(options =>
            options.MapControllers());
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.RoutePrefix = string.Empty;
        });



    }

}
