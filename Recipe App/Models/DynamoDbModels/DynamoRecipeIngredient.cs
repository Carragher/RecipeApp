using Amazon.DynamoDBv2.DataModel;

namespace Recipe_App.Models.DynamoDbModels
{
    [DynamoDBTable("RecipeIngredients")]
    public class DynamoRecipeIngredient
    {
        [DynamoDBHashKey("RecipeName")]
        public string RecipeName { get; set; }
        [DynamoDBProperty("IngredientNumber")]
        public int IngredientNumber { get; set; }
        [DynamoDBProperty("IngredientAmount")]
        public string IngredientAmount { get; set; }
        [DynamoDBProperty("IngredientName")]
        public string IngredientName { get; set; }

    }
}
