using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Recipe_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {

        public string SayHi()
        {
            return "I did the thing";
        }


    }
}
