using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Contract
{
    public interface IFeedBack
    {

        //GetAll Record
        List<FeedBack> GetAll();
        //Get single 
        FeedBack GetSingle(int id);
        //Add Record
        String Add(FeedBack feedBack);
        //Update or Edit Record
        String Update(int id, FeedBack feedBack);
        //Delete or Remove
        String Remove(int id);
    }
}
