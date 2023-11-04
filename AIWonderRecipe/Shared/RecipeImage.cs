using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIWonderRecipe.Shared
{
    public class RecipeImage
    {
        public int Created { get; set; }
        public ImageData[]? Data { get; set; }//Array allows for multiple images; we only need one
    }
    public class ImageData
    {
        public string? Url { get; set; }
    }
}
