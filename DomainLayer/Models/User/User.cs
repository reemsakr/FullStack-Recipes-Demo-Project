﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.User
{
    public class User
    {
        public string ?Id { get; set; }

        public string ?UserName { get; set; }
        [EmailAddress]
        public  string? Email { get; set; }
        public  string? Password { get; set; }
    }
}
