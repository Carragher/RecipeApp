namespace Recipe_App.Models;

public class RecipeTimeCard
{
    public decimal PrepTime { get; set; }
    public decimal CookTime { get; set; }
    public decimal RestTime { get; set; }
    public decimal TotalTime => CookTime + PrepTime + RestTime;

}