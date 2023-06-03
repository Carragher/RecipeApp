using Amazon.DynamoDBv2.DataModel;

namespace Recipe_App.Models.DynamoDbModels
{
    [DynamoDBTable("RecipeTimeCards")]
    public class DynamoRecipeTimeCard
    {
        [DynamoDBHashKey("RecipeName")]
        public string RecipeName { get; set; }
        [DynamoDBProperty("CookTime")]
        public decimal CookTime { get; set; }
        [DynamoDBProperty("PrepTime")]
        public decimal PrepTime { get; set; }
        [DynamoDBProperty("RestTime")]
        public decimal RestTime { get; set; }
    }
}
