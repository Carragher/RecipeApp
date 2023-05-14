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