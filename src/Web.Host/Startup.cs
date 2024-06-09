using Forpost.Business.Abstract.Services;
using Forpost.Business.Services;
using Forpost.Store.Postgres;
using Forpost.Store.Repositories;
using Forpost.Store.Repositories.Abstract.Repositories;
using Forpost.Web.Contracts.Controllers;
using Forpost.Web.Contracts.SettingsBlock;
using Microsoft.Extensions.Options;

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
        // ����������� ��������
        RegisterServices(services);

        // ����������� �������� CORS
        ConfigureCors(services);

        // ����������� ������������
        services.AddControllers();

        // ����������� ���� ������
        services.AddPostgresDbContext(_configuration);

        // ����������� �����������
        services.AddAuthorization();

        // ������������ Swagger
        ConfigureSwagger(services);

        // ����������� API Explorer
        services.AddEndpointsApiExplorer();
    }


    private void RegisterServices(IServiceCollection services)
    {
        services.AddTransient<IOrderBlocksRepository, OrderBlocksRepository>();
        services.AddTransient<IOrderBlocksService, OrderBlocksService>();
        services.AddTransient<ISettingsBlocksService, SettingsBlocksService>();
        services.AddTransient<ISettingsBlocksRepository, SettingsBlocksRepository>();
    }
    // ��������� CORS
    private void ConfigureCors(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins("http://localhost:3000")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });
    }

    private void ConfigureSwagger(IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(OrderBlocksController).Assembly.GetName().Name}.xml"));
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{typeof(SettingsBlockController).Assembly.GetName().Name}.xml"));
        });
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