using AIWonderRecipe.Server.Models.ChatEndPoint;
using AIWonderRecipe.Shared;
using System.Text.Json;

namespace AIWonderRecipe.Server.Services
{
    public class OpenAIAPIService : IOpenAIAPI
    {
        private readonly IConfiguration? _configuration;
        private static readonly string _baseUrl = "https://api.openai.com/v1/";
        private static readonly HttpClient _httpClient = new();
        private readonly JsonSerializerOptions? _jsonOptions;
       
        //build the function objects that will return JSON formatted object from the API
        private static ChatFunction.Parameter _recipeIdeaParameter = new()
        {
            // describes one Idea
            Type = "object",
            Required = new string[] { "index", "title", "description" },
            Properties = new
            {
                // provide a type and description for each property of the Idea model
                Index = new ChatFunction.Property
                {
                    Type = "number",
                    Description = "A unique identifier for this object",
                },
                Title = new ChatFunction.Property
                {
                    Type = "string",
                    Description = "The name for a recipe to create"
                },
                Description = new ChatFunction.Property
                {
                    Type = "string",
                    Description = "A description of the recipe"
                }
            }
        };

        private static ChatFunction _ideaFunction = new()
        {
            // describe the function we want an argument for from the AI
            Name = "CreateRecipe",
            // this description ensures we get 5 ideas back
            Description = "Generates recipes for each idea in an array of five recipe ideas",
            Parameters = new
            {
                // OpenAI requires that the parameters are an object, so we need to wrap our array in an object
                Type = "object",
                Properties = new
                {
                    Data = new // our array will come back in an object in the Data property
                    {
                        Type = "array",
                        // further ensures the AI will create 5 recipe ideas
                        Description = "An array of five recipe ideas",
                        Items = _recipeIdeaParameter
                    }
                }
            }
        };

        

        public Task<List<Idea>> CreateRecipeIdeas(string mealtime, List<string> ingredients)
        {
            throw new NotImplementedException();
        }
    }
}
