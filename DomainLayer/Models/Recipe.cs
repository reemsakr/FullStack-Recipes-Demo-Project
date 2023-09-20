using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Recipe
    {
        [Key]
        public int ?Id { get; set; }

        public required string Name { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public  List<IngredientRecipe>? IngredientRecipes { get; set; }

    }
}
