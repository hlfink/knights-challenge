namespace Knights.Challenge.Api;

/// <summary>
///  Interface to Startup
/// </summary>
public interface IStartup
{
    /// <summary>
    /// Variavel to connfig
    /// </summary>
    IConfiguration Configuration { get; }
    /// <summary>
    /// Config to services
    /// </summary>
    /// <param name="services"></param>
    /// <param name="env"></param>
    void ConfigureServices(IServiceCollection services, IWebHostEnvironment env);
    /// <summary>
    /// Configuration app
    /// </summary>
    /// <param name="app"></param>
    /// <param name="env"></param>
    void Configure(IApplicationBuilder app, IWebHostEnvironment env);
}
