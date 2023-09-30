using DomainLayer.Models.User;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class FeedBack:BaseEntity
    {
        [Key]
        public  int Id { get; set; }
        public int Rate { get; set; }

        public  string Review { get; set; }

       
        public  int  RecipeId { get; set; }

        public Recipe? Recipe { get; set; }


        ///[ForeignKey("ApplicationUser")]
        //public virtual int UserId { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
