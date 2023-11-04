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
        private readonly IOpenAIAPI _openAIAPIService;

        public RecipeController(IOpenAIAPI openAIAPIService)
        {
            _openAIAPIService = openAIAPIService;
        }

        [HttpPost, Route("GetRecipeIdeas")]
        public async Task<ActionResult<List<Idea>>> GetRecipeIdeas(RecipeParms recipeParms)
        {
            string mealtime = recipeParms.MealTime;
            List<string> ingredients = recipeParms.Ingredients
                                                  .Where(x => !string.IsNullOrEmpty(x.Description))
                                                  .Select(x => x.Description!)
                                                  .ToList();
            if (string.IsNullOrEmpty(mealtime))
            {
                mealtime = "Breakfast";
            }
            var ideas = await _openAIAPIService.CreateRecipeIdeas(mealtime, ingredients);

            return ideas;

            //Testing purposes only
            //return SampleData.RecipeIdeas;
        }
        [HttpPost, Route("GetRecipe")]
        public async Task<ActionResult<Recipe?>> GetRecipe(RecipeParms recipeParms)
        {
            List<string> ingredients = recipeParms.Ingredients
                                                  .Where(x => !string.IsNullOrEmpty(x.Description))
                                                  .Select(x => x.Description!)
                                                  .ToList();
            string? title = recipeParms.SelectedIdea;

            if (string.IsNullOrEmpty(title))
            {
                return BadRequest();
            }
           var recipe = await _openAIAPIService.CreateRecipe(title, ingredients);

            return recipe;

            //Testing purposes only
            //return SampleData.Recipe;
        }
        
        [HttpGet, Route("GetRecipeImage")]
        public async Task<ActionResult<RecipeImage?>> GetRecipeImage(string title)
        {
            var recipeImage = await _openAIAPIService.CreateRecipeImage(title);

            return recipeImage;

            //Testing purposes only
            //return SampleData.RecipeImage;
        }
    }
}
