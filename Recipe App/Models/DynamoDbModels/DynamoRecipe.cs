using Amazon.DynamoDBv2.DataModel;


namespace Recipe_App.Models.DynamoDbModels
{
    [DynamoDBTable("Recipes")]
    public class DynamoRecipe
    {

        [DynamoDBProperty("DateCreated")]
        public int DateCreated { get; set; }

        [DynamoDBProperty("Description")]
        public string Description { get; set; }

        [DynamoDBProperty("IsDeleted")]
        public bool IsDeleted { get; set; }

        [DynamoDBProperty("Note")]
        public string Note { get; set; }

        [DynamoDBHashKey("RecipeName")]
        public string Name { get; set; }


    }
}
