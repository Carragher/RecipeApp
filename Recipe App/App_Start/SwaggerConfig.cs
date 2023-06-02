using System.Web.Http;
using Swashbuckle.Application;

namespace Recipe_App.App_Start
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "First WEB API Demo");
                })
                .EnableSwaggerUi();
        }
    }
}
