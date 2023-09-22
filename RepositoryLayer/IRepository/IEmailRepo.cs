using DomainLayer.Models;
using DomainLayer.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.IRepository
{
    public interface IEmailRepo<T> where T:EmailModel 
    {

        void SendEmail(Message message);
    }
}
