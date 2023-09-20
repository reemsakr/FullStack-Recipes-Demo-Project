using DomainLayer.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLayer.Interface
{
    public interface IEmail
    {
        void SendEmail(Message message); 

    }
}
