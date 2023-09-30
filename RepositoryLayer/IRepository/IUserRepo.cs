using DomainLayer.Models;
using DomainLayer.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IUserRepo<T> where T:User
    {

        //GetAll Record
        List<UsersViewModel> GetAllRepo();
        //GetSingle Record
        UsersViewModel GetSingleRepoAsync(string id);
        //Add Record
        Task<string> AddRepo(T userObj, string role);
        //Update or Edit Record
        Task<String> UpdateRepoAsync(string id, T userObj);
        //Delete or Remove
        Task<String> Remove(string id);
        //Authentication
        Task<string> Login(LoginReq userObj);
       // Task<string> ForgetPassword(string email);
    }
}
