using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    
    public interface IRepo<T> where T :BaseEntity
    {
        //GetAll Record
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        
        //Add Record
        String Add(T recipe);
        //Update or Edit Record
        String Update(int id, T recipe);
        //Delete or Remove
        String Remove(int id);
    }
    
}
