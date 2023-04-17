namespace Knights.Challenge.Api.Extensions;

/// <summary>
///  Extension to startup
/// </summary>
public static class StatupExtension
{
    /// <summary>
    /// Method to extension
    /// </summary>
    /// <typeparam name="TStartup"></typeparam>
    /// <param name="builder"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Configuration
            .SetBasePath(builder.Environment.ContentRootPath)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", false, false);


        var startup = Activator.CreateInstance(typeof(TStartup), builder.Configuration) as IStartup;
        if (startup == null) throw new ArgumentException("Classe Startup inválida");


        startup.ConfigureServices(builder.Services, builder.Environment);

        var app = builder.Build();
        startup.Configure(app, app.Environment);

        app.Run();

        return builder;
    }
}
