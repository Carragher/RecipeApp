using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipe_App.Helpers;
using Recipe_App.Models;
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
                context.Dispose();
                return Ok(returnMe);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }

        }
        

        [HttpGet]
        public async Task<IActionResult> ReadRecipe(string recipeName)
        {
            try
            {
                DynamoDBContext context = new DynamoDBContext(DynamoClient);

                DynamoRecipe recipe = await context.LoadAsync<DynamoRecipe>(recipeName);
                List<DynamoRecipeIngredient> ingredients =
                    await context.QueryAsync<DynamoRecipeIngredient>(recipeName).GetRemainingAsync();
                List<DynamoRecipeInstruction> instructions =
                    await context.QueryAsync<DynamoRecipeInstruction>(recipeName).GetRemainingAsync();
                DynamoRecipeTimeCard recipeTimeCard = await context.LoadAsync<DynamoRecipeTimeCard>(recipeName);

                Recipe recipeViewModel = RecipeBuilderHelper.BuildRecipe(recipe,ingredients,instructions,recipeTimeCard);
                

                return Ok(recipeViewModel);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ReadAllRecipes()
        {
            try
            {
                Dictionary<string, AttributeValue> startKey = null;
                var returnMe = new List<string>();
                returnMe = await BuildRecipeTableReturn();
                return Ok(returnMe);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500);
            }
        }

        private async Task<List<string>> BuildRecipeTableReturn(string paginationToken = "")
        {
            List<string> returnMe = new List<string>();
            DynamoDBContext context = new DynamoDBContext(DynamoClient);
            var table  = context.GetTargetTable<DynamoRecipe>();
            var scanOps = new ScanOperationConfig();

            if (!string.IsNullOrEmpty(paginationToken))
            {
                scanOps.PaginationToken = paginationToken;
            }

            var scanResults = table.Scan(scanOps);
            List<Document> data = await scanResults.GetNextSetAsync();
            var recipes = context.FromDocuments<DynamoRecipe>(data);
            returnMe = recipes.Select(x => x.RecipeName).ToList();

            if (!string.IsNullOrEmpty(scanResults.PaginationToken) && scanResults.PaginationToken != "{}")
            {
                var addition = await BuildRecipeTableReturn(scanResults.PaginationToken);
                returnMe = returnMe.Concat(addition).ToList();
            }

            return returnMe;

        }


        [HttpPost]
        public async Task<IActionResult> SaveNewRecipe([FromBody] Recipe recipe)
        {


            throw new NotImplementedException();
        }






    }// I am the controller class Do not write below or you are dumb
}
