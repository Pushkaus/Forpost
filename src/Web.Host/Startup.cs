using Forpost.Store.Postgres;
using Forpost.Web.Contracts.Controllers;
using Microsoft.OpenApi.Models;

namespace Forpost.Web.Host;

internal sealed class Startup
{

    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("http://localhost:3000");
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            });
        });
        services.AddControllers();
        services.AddPostgresDbContext(_configuration);
        services.AddAuthorization();
        services.AddSwaggerGen(options =>
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(OrderBlocksController).Assembly.GetName().Name}.xml")
            ));
        services.AddEndpointsApiExplorer();

    }

    public void Configure(IApplicationBuilder app, IHostEnvironment environment, ILogger<Startup> logger)
    {
        app.UseCors();
        app.UseRouting();
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.RoutePrefix = string.Empty;
        });

        app.UseEndpoints(options =>
            options.MapControllers());

    }
}