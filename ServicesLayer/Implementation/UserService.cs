using Azure.Core;
using DomainLayer.Models;
using DomainLayer.Models.User;
using Microsoft.AspNetCore.Identity;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer;
using RepositoryLayer.IRepository;
using ServicesLayer.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace ServicesLayer.Implementation
{
    public class UserService : IUser
    {
        private IUserRepo<User> UserRepository;
        public UserService(IUserRepo<User> UserRepository)
        {
            this.UserRepository = UserRepository;

        }

       
        public async Task<string> AddRepo(User userObj, string role)
        {
            return await UserRepository.AddRepo(userObj, role);
        }
       
        public List<UsersViewModel> GetAllRepo()
        {
            return UserRepository.GetAllRepo();
        }
        
   public  UsersViewModel GetSingleRepoAsync(string id)
   {

            return UserRepository.GetSingleRepoAsync(id);


   }
  
   public async Task<string> Login(LoginReq userObj)
   {
            return await  UserRepository.Login(userObj);
   }
        /*
       public async Task<string> ForgetPassword(string email)
        {
           return UserRepository.ForgetPassword(email);
        }
        /*/


        public async Task< string> Remove(string id)
   {
            return await UserRepository.Remove(id);
   }
        
   public async Task<string> UpdateRepoAsync(string id, User userObj)
   {
            return await UserRepository.UpdateRepoAsync(id, userObj);
   }
   
    }
}
