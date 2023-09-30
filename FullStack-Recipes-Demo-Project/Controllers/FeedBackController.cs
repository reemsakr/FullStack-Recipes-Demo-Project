using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ServiceLayer.Service.Contract;

namespace FullStack_Demo_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {

        private readonly IFeedBack _feedback;
        private readonly IMemoryCache _cache;
        public FeedBackController(IFeedBack feedback, IMemoryCache cache)
        {
            this._feedback = feedback;
            this._cache = cache;
        }

        //Get All feedbacks
        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAllRecords()
        {
            Console.WriteLine("here");
            var response = this._feedback.GetAll();
            if (response.Count() == 0) return NotFound("No FeedBacks Found");
            return Ok(response);
        }



        //Get Single Record
        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> GetSingleRecords([FromRoute] int id)
        {
            var response = this._feedback.GetSingle(id);
            if (response != null) return Ok(response);
            return NotFound("No FeedBacks Found");

        }
        //Add ingredient 
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddRecords(FeedBack feedBack)
        {
            var response = this._feedback.Add(feedBack);
            
             return Ok(response);
        }


        //Remove feedback
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveRecords([FromRoute] int id)
        {
            var response = this._feedback.Remove(id);
            if (response == "Not Found FeedBack.") return NotFound(response);
            return Ok(response);
        }
        //Update FeedBack
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRecords([FromRoute] int id, FeedBack feedBack)
        {
            var response = this._feedback.Update(id, feedBack);
           
            if (response == "Not Found feedbacks.") return NotFound(response);
            return Ok(response);
        }
    }
}
