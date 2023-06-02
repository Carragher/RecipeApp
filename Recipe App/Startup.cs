using System.Web.Http;
using Swashbuckle.Application;

namespace Recipe_App;

public class Startup
{
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
        
    }


    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
    }


}

public class SwaggerConfig
{
    public static void Register()
    {
        var thisAssembly = typeof(SwaggerConfig).Assembly;
        GlobalConfiguration.Configuration
            .EnableSwagger(c => c.SingleApiVersion("v1", "Recipeapp"))
            .EnableSwaggerUi();
    }
}