using Knights.Challenge.Adapters.Database.MongoDB;
using Knights.Challenge.Adapters.Database.MongoDB.Repositories;
using Knights.Challenge.Core.Application.Ports;
using Knights.Challenge.Core.Application.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Knights.Challenge.Api;
public class Startup : IStartup
{
    /// <summary>
    /// propriedade para recuperar appsettings
    /// </summary>
    public IConfiguration Configuration { get; }
    /// <summary>
    /// Contrutor injetando a apropriedade de configuração
    /// </summary>
    /// <param name="configuration"></param>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services, IWebHostEnvironment env)
    {
        services.AddControllers();
        services.AddApiVersioning();
        services.AddSwaggerGen();

        services.AddEndpointsApiExplorer();
        services.Configure<MongoDBConfig>(Configuration.GetSection("MongoDB"));
        services.AddTransient(typeof(IMongoDBContext), typeof(MongoDBContext));
        services.AddTransient(typeof(IKnightsRepositoryAdapterPort), typeof(KnightsRepositoryAdapter));
        services.AddTransient(typeof(IKnightService), typeof(KnightService));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options => {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

        app.UseExceptionHandler(a => a.Run(async context =>
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature?.Error;

            await context.Response.WriteAsJsonAsync(new { error = exception?.Message });
        }));

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
