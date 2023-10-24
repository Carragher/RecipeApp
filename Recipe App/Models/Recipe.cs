namespace Recipe_App.Models;

public class Recipe
{
    public string RecipeName { get; set; }
    public string Description { get; set; }
    public string Notes { get; set; }
    public string Author { get; set; }
    public RecipeTimeCard TimeCard { get; set; }
    public List<RecipeIngredient> Ingredients { get; set; }
    public List<RecipeInstruction> Instructions { get; set; }




}