using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe_App.Models;
using Recipe_App.Models.DynamoDbModels;

namespace Recipe_App.Helpers
{
    public class RecipeBuilderHelper
    {
        

        public RecipeBuilderHelper()
        {

        }

        public static Recipe BuildRecipe(DynamoRecipe recipe, List<DynamoRecipeIngredient> ingredients,
            List<DynamoRecipeInstruction> instructions, DynamoRecipeTimeCard recipeTimeCard)
        {
            var returnMe = new Recipe()
            {
                Description = recipe.Description,
                Notes = recipe.Note,
                RecipeName = recipe.RecipeName,
                Author = recipe.Author,
                TimeCard = new RecipeTimeCard(recipeTimeCard),
                Ingredients = RecipeBuilderHelper.BuildIngredients(ingredients),
                Instructions = RecipeBuilderHelper.BuildInstructions(instructions)
            };


            return returnMe;
        }

        public static List<RecipeInstruction> BuildInstructions(List<DynamoRecipeInstruction> instructions)
        {
            var returnMe = new List<RecipeInstruction>();
            foreach (var instruction in instructions)
            {
                returnMe.Add(new RecipeInstruction()
                {
                    Step = instruction.InstructionNumber,
                    Text = instruction.InstructionText

                });
            }
            return returnMe;
        }

        public static List<RecipeIngredient> BuildIngredients(List<DynamoRecipeIngredient> ingredients)
        {
            var returnMe = new List<RecipeIngredient>();

            foreach (var ingredient in ingredients)
            {
                    returnMe.Add(new RecipeIngredient()
                    {
                        IngredientAmount = ingredient.IngredientAmount,
                        IngredientName = ingredient.IngredientName,
                        IngredientNumber = ingredient.IngredientNumber

                    });
            }

            returnMe = returnMe.OrderBy(x => x.IngredientNumber).ToList();
            return returnMe;
        }
    }
}
