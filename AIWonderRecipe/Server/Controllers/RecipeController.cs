
using AIWonderRecipe.Server.Data;
using AIWonderRecipe.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AIWonderRecipe.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        [HttpPost, Route("GetRecipeIdeas")]
        public async Task<ActionResult<List<Idea>>> GetRecipeIdeas(RecipeParms recipeParms)
        {

            return SampleData.RecipeIdeas;
        }
    }
}
