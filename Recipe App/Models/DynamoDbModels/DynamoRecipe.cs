using Amazon.DynamoDBv2.DataModel;


namespace Recipe_App.Models.DynamoDbModels
{
    [DynamoDBTable("Recipe")]
    public class DynamoRecipe
    {
        [DynamoDBHashKey("RecipeId")]
        public int Id { get; set; }

        [DynamoDBProperty("DateCreated")]
        public string DateCreated { get; set; }

        [DynamoDBProperty("Description")]
        public string Description { get; set; }

        [DynamoDBProperty("IsDeleted")]
        public bool IsDeleted { get; set; }

        [DynamoDBProperty("Note")]
        public string Note { get; set; }

        [DynamoDBProperty("RecipeName")]
        public string Name { get; set; }


    }
}
