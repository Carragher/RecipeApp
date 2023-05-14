using Microsoft.AspNetCore.Hosting;

namespace Recipe_App // Note: actual namespace depends on the project name.
{
    public class Program
    {
        static void Main()
        {
            CreateHostBuilder().Build().Run();
        }
        public static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webHost => {
                webHost.UseStartup<Startup>();
            });
        }
        
    }
}