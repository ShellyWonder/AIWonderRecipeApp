
using AIWonderRecipe.Server.Data;
using AIWonderRecipe.Server.Services;
using AIWonderRecipe.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AIWonderRecipe.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    { 
        private readonly IOpenAIAPI _openAIService;

        public RecipeController(IOpenAIAPI openAIService)
        {
            _openAIService = openAIService;
        }

        [HttpPost, Route("GetRecipeIdeas")]
        public async Task<ActionResult<List<Idea>>> GetRecipeIdeas(RecipeParms recipeParms)
        {
            //string mealtime = recipeParms.MealTime;
            //List<string> ingredients = recipeParms.Ingredients
            //                                      .Where(x => !string.IsNullOrEmpty(x.Description))
            //                                      .Select(x => x.Description!)
            //                                      .ToList();
            //if (string.IsNullOrEmpty(mealtime))
            //{
            //    mealtime = "Breakfast";
            //}
            //var ideas = await _openAIService.CreateRecipeIdeas(mealtime, ingredients);

            //return ideas;

            //Testing purposes only
            return SampleData.RecipeIdeas;
        }
    }
}

