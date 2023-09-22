
using DomainLayer.Models;
using DomainLayer.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.IRepository;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class UserRepo<T> : IUserRepo<T> where T:User
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _config;
        private readonly AppDbContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public UserRepo(AppDbContext context, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.context = context;
            entities = context.Set<T>();
            _userManager = userManager;
            _roleManager = roleManager;
            _config = configuration;
        }
        private bool CheckEmailExistAsync(string? email)
            => context.Users.Any(x => x.Email == email);

        private bool CheckUserNameExistAsync(string? userName)
            => context.Users.Any(x => x.UserName == userName);

        private static string CheckPasswordStrength(string pass)
        {
            StringBuilder sb = new StringBuilder();
            if (pass.Length < 9)
                sb.Append("Minimum password length should be 8" + Environment.NewLine);
            if (!(Regex.IsMatch(pass, "[a-z]") && Regex.IsMatch(pass, "[A-Z]") && Regex.IsMatch(pass, "[0-9]")))
                sb.Append("Password should be AlphaNumeric" + Environment.NewLine);
            if (!Regex.IsMatch(pass, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,~,`,-,=]"))
                sb.Append("Password should contain special charcter" + Environment.NewLine);
            return sb.ToString();
        }

        private async Task<string> CreateJwt(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysceret.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                 new Claim(ClaimTypes.Name,$"{user.Email}"),
                 new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            });
            var userRoles = await _userManager.GetRolesAsync(user);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        public async Task<string> AddRepo(T userObj, string role)
        {
            try
            {
                if (userObj == null)
                    return "This email is registered before.Please try with another email";
                var x = userObj.Email;
                // check email
                if (CheckEmailExistAsync(userObj.Email))
                    return ("This email is registered before.Please try with another email");

                if (CheckUserNameExistAsync(userObj.UserName))
                    return ("This UserName is registered before.Please try with another UserName");


                var passMessage = CheckPasswordStrength(userObj.Password);
                if (!string.IsNullOrEmpty(passMessage))
                    return (passMessage.ToString());

                IdentityUser user = new()
                {
                    Email = userObj.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = userObj.UserName

                };
                if (await _roleManager.RoleExistsAsync(role))
                {
                    var result = await _userManager.CreateAsync(user, userObj.Password);


                    if (!result.Succeeded)
                    {
                        return "User Failed to Create";
                    }

                    var t = await _userManager.AddToRoleAsync(user, role);

                    return ("Success Registration");

                }
                else return "This Role Doesnot exist.";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<UsersViewModel> GetAllRepo()
        {
            var users = _userManager.Users.Select(c => new UsersViewModel()
            {
                Id = c.Id,
                Username = c.UserName,
                Email = c.Email,
                Role = string.Join(",", _userManager.GetRolesAsync(c).Result.ToArray())
            }).ToList();

            return (users);
        }

        public UsersViewModel GetSingleRepoAsync(string id)
        {

            var user = _userManager.Users.Select(c => new UsersViewModel()
            {
                Id = id,
                Username = c.UserName,
                Email = c.Email,
                Role = string.Join(",", _userManager.GetRolesAsync(c).Result.ToArray())
            }).FirstOrDefault();


            return user;

        }

        public async Task<string> Login(LoginReq userObj)
        {
            try
            {
                if (userObj == null) return "their is a wrong in Email or Passowrd.";

                var user = await _userManager.FindByNameAsync(userObj.UserName);

                if (user != null && await _userManager.CheckPasswordAsync(user, userObj.Password))
                {

                    var authClaims = new ClaimsIdentity(new Claim[]
                    {
                         new Claim(ClaimTypes.Name,$"{user.Email}"),
                         new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    });
                    var userRoles = await _userManager.GetRolesAsync(user);
                    foreach (var role in userRoles)
                    {
                        authClaims.AddClaim(new Claim(ClaimTypes.Role, role));
                    }
                    String token = await CreateJwt(user);
                    return $" `Login Successfully with this token =  {token}`";
                }

                return "their is a wrong in Email or Passowrd.";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /*
       public async Task<string> ForgetPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if(user!=null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var link = this.Url.Action("ResetPassword", "Authentication", new { token, email = user.Email }, Request.Schema);
            }
            return "";
        }
        /*/


        public async Task<string> Remove(string id)
        {
            try
            {
                var data = await _userManager.FindByIdAsync(id);
                if (data != null)
                {
                    
                   await  _userManager.DeleteAsync(data);
                    context.SaveChanges();
                    return ("Delete success");
                }

                return "Not Found User.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> UpdateRepoAsync(string id, T userObj)
        {
            try
            {
                var data = await _userManager.FindByIdAsync(id);

                if (data != null)
                {
                    if (userObj.Email != null)
                    {
                        var test = await _userManager.FindByEmailAsync(userObj.Email);
                        if (test != null)
                        {
                            return ("You have to enter a unique email for your profile");
                        }
                    }


                    if (userObj.UserName != null)
                        data.UserName = userObj.UserName;
                    if (userObj.Email != null)
                        data.Email = userObj.Email;
                    if (userObj.Password != null)
                        data.PasswordHash = userObj.Password;


                    context.SaveChanges();
                    return ("Success Update");
                }
                return ("Not Found User.");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}