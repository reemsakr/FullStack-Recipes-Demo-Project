using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ServiceLayer.Service.Contract;

namespace FullStack_Demo_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientController : ControllerBase
    {

        private readonly IIngredient _ingredient;
        private readonly IMemoryCache _cache;
        public IngredientController(IIngredient ingredient,IMemoryCache cache)
        {
            this._ingredient = ingredient;
            this._cache = cache;
        }

        //Get All ingredient
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllRecords()
        {
            var response = this._ingredient.GetAllRepo();
            if (response.Count() == 0) return NotFound("No ingredient Found");
            return Ok(response);
        }



        //Get Single Record
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetSingleRecords([FromRoute] int id)
        {
            var response = this._ingredient.GetSingleRepo(id);
            if (response != null) return Ok(response);
            return NotFound("No ingredient Found");

        }
        //Add ingredient 
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddRecords(Ingredient IngredientRequest)
        {
            var response = this._ingredient.AddIngredientRepo(IngredientRequest);
            if (response == "This ingredient is already here")
            {
                return BadRequest(response);
            }
            else return Ok(response);
        }


        //Remove ingredient
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveRecords([FromRoute] int id)
        {
            var response = this._ingredient.RemoveIngredient(id);
            if (response == "Not Found ingredient.") return NotFound(response);
            return Ok(response);
        }
        //Update ingredient
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRecords([FromRoute] int id, Ingredient IngredientRequest)
        {
            var response = this._ingredient.UpdateIngredientRepo(id, IngredientRequest);
            if (response == "You have to enter a unique name for your ingredient.")
                return BadRequest(response);
            if (response == "Not Found ingredient.") return NotFound(response);
            return Ok(response);
        }
    }
}
