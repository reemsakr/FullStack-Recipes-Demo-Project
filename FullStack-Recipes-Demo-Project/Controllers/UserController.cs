using DomainLayer.Models;
using DomainLayer.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Interface;
using System.ComponentModel.DataAnnotations;

namespace FullStack_Recipes_Demo_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUser _user;
        private readonly IEmail _email;
        private readonly UserManager<IdentityUser> _userManager;
        public UserController(IUser user, IEmail email,UserManager<IdentityUser> userManager)
        {
            this._user = user;
            this._email = email;
            _userManager = userManager;
        }
        
        //Get All users
        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAllRecords()
        {
            
            var response = this._user.GetAllRepo();
            if (response.Count() == 0) return NotFound("No users Found");
            return Ok(response);
        }
        

        
        //Get Single Record
        [HttpGet]
        [Route("get/{id}")]
       public IActionResult GetSingleRecords([FromRoute] string id)
        {
            var response = this._user.GetSingleRepoAsync(id);
            if (response != null) return Ok(response);
            return NotFound("No user Found");

        }
       
        //Add user 
        [HttpPost]
        [Route("add/{role}")]
        public async Task<IActionResult> AddRecords([FromBody] User UserRequest,[FromRoute] string role)
        {
            
            var response =await  _user.AddRepo(UserRequest,role);
            if (response == "This email is registered before.Please try with another email")
            {
                return BadRequest(response);
            }
            if (response == "This Role Doesnot exist.") return BadRequest(response);
            if (response == "User Failed to Create") return Problem(response);
            if (response == "Success Registration")
                return Ok(response);
            else return BadRequest(response);
        }
        
        
        //Remove User
        //[Authorize]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RemoveRecords([FromRoute] string id)
        {
            var response = await this._user.Remove(id);
            if (response == "Not Found User.") return NotFound(response);
            return Ok(response);
        }
        
        //Update User
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateRecords([FromRoute] string id,[FromBody] User UserRequest)
        {
            var response =await _user.UpdateRepoAsync(id, UserRequest);
            if (response == "You have to enter a unique email for your profile")
                return BadRequest(response);
            if (response == "Not Found User.") return NotFound(response);
            return Ok(response);
        }
        //*/
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginReq UserRequest)
        {
            var response = await _user.Login(UserRequest);
            if (response == "their is a wrong in Email or Passowrd.")
                return BadRequest(response);
           
            return Ok(response);
        }


        [HttpPost("ForgetPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgetPassword([Required] string email)
        {
            Console.Write("hereeeeeeeeeeee");
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
               //  var link = this.Url.Action("ResetPassword", "Authentication", new { token, email = user.Email }, Request.Scheme);
                var message = new Message(email, "Forgot Password link",token);
                Console.WriteLine(message.Content);
                _email.SendEmail(message);
                return Ok("Success sent!");
            }
            return BadRequest("Couldnot send link to email ,please try again .");
           
        }

        [HttpPost("ResetPassword")]

        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            var model = new ResetPassword { Token =token,Email = email };
            return Ok(new { model });
        }
    }
}
