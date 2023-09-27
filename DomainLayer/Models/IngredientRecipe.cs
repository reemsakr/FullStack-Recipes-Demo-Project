using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class IngredientRecipe :BaseEntity
    {


        [Key]
        public int? Id { get; set; }
        public int ?IngredientsId { get; set; }
        public Ingredient? Ingredient { get; set; }
        public int ?RecipesId { get; set; }
        public Recipe ?Recipe { get; set; }


    }
}
