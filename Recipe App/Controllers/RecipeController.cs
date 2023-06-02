using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe_App.Models.DynamoDbModels;

namespace Recipe_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {

        private readonly static AmazonDynamoDBClient DynamoClient = new AmazonDynamoDBClient();

        [HttpGet]
        public async Task<IActionResult> SayHi()
        {
            try
            {
                DynamoDBContext context = new DynamoDBContext(DynamoClient);
                DynamoRecipe returnMe = await context.LoadAsync<DynamoRecipe>(1);
                return Ok(returnMe);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }


    }
}
