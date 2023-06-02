namespace Recipe_App.Models;

public class Recipe
{
    public int RecipeId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Notes { get; set; }
    public RecipeTimeCard TimeCard { get; set; }
    public List<RecipeIngredientContainer> Ingredients { get; set; }
    public List<RecipeInstructionContainer> Instructions { get; set; }
    



}