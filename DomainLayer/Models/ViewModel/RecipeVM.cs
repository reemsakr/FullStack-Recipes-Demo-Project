using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ViewModel
{
    public class RecipeVM
    {
        public required string Name { get; set; }
    }

    public class RecipeWithIngredientsVM
    {
        public required string Name { set; get; }

        public required List<string> IngredientName { get; set; }
    }
    public class RecipeWithFeedBacksVM
    {
        public required string Name { set; get; }

        public required List<int> Rates { get; set; }
        public required List<string> Reviews { get; set; }
    }
}
