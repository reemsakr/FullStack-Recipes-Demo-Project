﻿using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Contract
{
    public interface IIngredient
    {

        //GetAll Record
        List<Ingredient> GetAll();
        //Get single 
        Ingredient GetSingle(int id);
        //Add Record
        String Add(Ingredient ingredient);
        //Update or Edit Record
        String Update(int id, Ingredient ingredient);
        //Delete or Remove
        String Remove(int id);
    }
}
