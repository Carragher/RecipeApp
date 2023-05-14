namespace Recipe_App.Models;

public class RecipeInstructionContainer
{
    public string InstructionTitle { get; set; }
    public int InstructionId { get; set; }
    public List<RecipeInstruction> Instructions { get; set; }

}