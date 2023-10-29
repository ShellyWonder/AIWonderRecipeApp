using AIWonderRecipe.Shared;

namespace AIWonderRecipe.Server.Services
{
    public interface IOpenAIAPI
    {
        Task<List<Idea>> CreateRecipeIdeas(string mealtime, List<string> ingredients);
    }
}
