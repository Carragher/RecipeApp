using Amazon.DynamoDBv2.DataModel;

namespace Recipe_App.Models.DynamoDbModels
{
    [DynamoDBTable("RecipeInstructions")]
    public class DynamoRecipeInstruction
    {
        [DynamoDBHashKey("RecipeName")]
        public string RecipeName { get; set; }
        [DynamoDBProperty("InstructionNumber")]
        public string InstructionNumber { get; set; }
        [DynamoDBProperty("InstructionText")]
        public string InstructionText { get; set; }

    }
}
