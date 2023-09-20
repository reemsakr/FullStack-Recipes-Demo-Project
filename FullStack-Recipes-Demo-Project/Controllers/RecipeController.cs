using DomainLayer.Models;
using DomainLayer.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Service.Contract;

namespace FullStack_Demo_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipe _recipe;

        public RecipeController(IRecipe recipe)
        {
            this._recipe = recipe;
        }

        //Get All Recipe
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllRecords()
        {
            var response =  this._recipe.GetAllRepo();
            if (response.Count() == 0) return NotFound("No Recipes Found");
            return Ok(response);
        }



        //Get Single Record
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetSingleRecords([FromRoute] int id)
        {
            var response = this._recipe.GetSingleRepo(id);
            if(response!=null)return Ok(response);
            return NotFound("No Recipes Found");

        } 
        //Add Recipe 
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddRecords(Recipe recipeRequest)
        {
            var response =this._recipe.AddRecipeRepo(recipeRequest);
            if (response == "This recipe is already here")
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }


        //Remove Recipe
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveRecords([FromRoute] int id)
        {
            var response=this._recipe.RemoveRecipe(id);
            if (response == "Not Found Recipe.") return NotFound(response);
            return Ok(response);
        }
        //Update Recipe
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRecords([FromRoute] int id,Recipe recipeRequest)
        {
            var response = this._recipe.UpdateRecipeRepo(id,recipeRequest);
            if (response == "You have to enter a unique name for your recipe")
                return BadRequest(response);
            if (response == "Not Found Recipe.") return NotFound(response);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetRecipeWithIngredientById/{id}")]
        public async Task<IActionResult> GetRecipeWithIngredient([FromRoute] int id)
        {

            var response = this._recipe.GetRecipeWithIngredients(id);
            if (response == null) return NotFound("No Recipes Found.");
            return Ok(response);
        }
        [HttpPost]
        [Route("GetRecipeByListOfIngredient")]
        public async Task<IActionResult> GetRecipeByListOfIngredient(List<String>Ingredients)
        {
            var response = this._recipe.GetRecipeByListOfIngredient(Ingredients);
            if (response == "Please enter the correct Ingredients.") return BadRequest(response);
            if (response == "No matching recipes found.") return NotFound(response);
            return Ok(response);
        }
        [HttpPost]
        [Route("/SearchForRecipeByName")]
        public async Task<IActionResult> SearchByName(String name)
        {
            var response = this._recipe.SearchByName(name);
            if (response == null) return NotFound("No Recipes Found.");
            return Ok(response);
        }
    }
}
