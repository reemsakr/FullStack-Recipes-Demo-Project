using DomainLayer.Models.User;
using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Interface
{
    public interface IUser
    {
        //GetAll Record
        List<UsersViewModel> GetAllRepo();
        //GetSingle Record
         UsersViewModel GetSingleRepoAsync(string id);
        //Add Record
        Task< string >AddRepo(User userObj,string role);
        //Update or Edit Record
        Task<String> UpdateRepoAsync(string id, User userObj);
        //Delete or Remove
        Task<String> Remove(string id);
        //Authentication
       Task< string> Login(LoginReq userObj);
        //Task<string> ForgetPassword(string email);
    }
}
