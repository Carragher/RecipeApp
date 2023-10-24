using Recipe_App.Models.DynamoDbModels;

namespace Recipe_App.Models;

public class RecipeTimeCard
{
    public RecipeTimeCard(DynamoRecipeTimeCard recipeTimeCard)
    {
        this.PrepTime = recipeTimeCard.PrepTime;
        this.CookTime = recipeTimeCard.CookTime;
        this.RestTime = recipeTimeCard.RestTime;
    }

    public decimal PrepTime { get; set; }
    public decimal CookTime { get; set; }
    public decimal RestTime { get; set; }
    public decimal TotalTime => CookTime + PrepTime + RestTime;

}