using AIWonderRecipe.Shared;
namespace AIWonderRecipe.Server.Data
{
    public static class SampleData
    {
        public static List<Idea> RecipeIdeas = new()
        {
            new Idea
            {
                Index = 0,
                Title = "Chocolate Chip Cookies",
                Description = "Delicious chocolate chip cookies made with browned butter"
            },
            new Idea
            {
                Index = 1,
                Title = "Peanut Butter Cookies",
                Description = "Cookies made with peanut butter and butterscotch chips. Yum!"
            },
            new Idea {
                Index = 2,
                Title = "Snickerdoodles",
                Description = "Classic snickerdoodle cookies. The secret ingredient is cream of tartar!"
            },
            new Idea {
                Index = 2,
                Title = "Sugar Cookies",
                Description = "A sugar cookie is a cookie with the main ingredients being sugar, flour, butter, eggs, vanilla, and either baking powder or baking soda."
            },
            new Idea {
                Index = 2,
                Title = "Ginger Snaps",
                Description = "Ginger snaps are a classic favorite. With just a few ingredients and even fewer steps this recipe for fabulous, spicy cookies is truly a snap to make."
            },
        };
    }
}

