using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service.Contract;

namespace FullStack_Demo_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientRecipeController : ControllerBase
    {
        private readonly IIngredientRecipe _ingredientRecipe;

        public IngredientRecipeController(IIngredientRecipe ingredientRecipe)
        {
            this._ingredientRecipe = ingredientRecipe;
        }

        //Get All ingredientRecipe
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllRecords()
        {
            var response = this._ingredientRecipe.GetAll();
            if (response.Count() == 0) return NotFound("No ingredientRecipe Found");
            return Ok(response);
        }



        //Get Single Record
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetSingleRecords([FromRoute] int id)
        {
            var response = this._ingredientRecipe.GetSingle(id);
            if (response != null) return Ok(response);
            return NotFound("No ingredientRecipe Found");

        }
        //Add _ingredientRecipe 
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddRecords(IngredientRecipe ingredientRecipeRequest)
        {
            var response = this._ingredientRecipe.Add(ingredientRecipeRequest);
            if (response == "This IngredientRecipe is already here")
            {
                return BadRequest(response);
            }
            if (response == "Please enter the correct IDs") return BadRequest(response);
            if (response == "this ingriedient is already in this recipe.") return BadRequest(response);
            return Ok(response);
        }


        //Remove ingredientRecipe
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveRecords([FromRoute] int id)
        {
            var response = this._ingredientRecipe.Remove(id);
            if (response == "Not Found ingredient.") return NotFound(response);
            return Ok(response);
        }
        //Update ingredientRecipe
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRecords([FromRoute] int id, IngredientRecipe IngredientRecipeRequest)
        {
            var response = this._ingredientRecipe.Update(id, IngredientRecipeRequest);
            if (response == "Please enter the correct IDs")
                return BadRequest(response);
            if (response == "Not Found IngredientRecipeRequest.") return NotFound(response);
            return Ok(response);
        }
    }
}
